using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrismaWEB.Models;
using PrismaWEB.Models.Enumerables;
using PrismaWEB.Validacoes;

namespace PrismaWEB.Controllers
{
    public class CandidatosController : Controller
    {
        private PrismaEntities db = new PrismaEntities();

        // GET: Candidatos
        public ActionResult Index()
        {
            var pESSOAS = db.PESSOAS.Include(p => p.BAIRROS).Include(p => p.ESTADOS).Include(p => p.LOGRADOUROS).Include(p => p.MUNICIPIOS).Include(p => p.PAISES).Where(m => m.Tipo ==1);
            return View(pESSOAS.ToList());
        }

        // GET: Candidatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PESSOAS pESSOAS = db.PESSOAS.Find(id);
            if (pESSOAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cargos = db.CARGOS.SqlQuery($@"select * 
                                                   from CARGOS 
                                                   where id in (
                                                        select Cargo_Id 
                                                        from CANDIDATOCARGO 
                                                        where Candidato_Id = {pESSOAS.Id} )");
            return View(pESSOAS);
        }

        // GET: Candidatos/Create
        public ActionResult Create()
        {
            ViewBag.Bairro_Id = new SelectList(db.BAIRROS, "Id", "Nome");
            ViewBag.Estado_Id = new SelectList(db.ESTADOS, "Id", "Nome");
            ViewBag.Logradouro_Id = new SelectList(db.LOGRADOUROS, "Id", "Nome");
            ViewBag.Municipio_Id = new SelectList(db.MUNICIPIOS, "Id", "Nome");
            ViewBag.Pais_Id = new SelectList(db.PAISES, "Id", "Nome");
            return View();
        }

        // POST: Candidatos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,DataNascimento,Cpf,Foto,DataCriacao,DataAlteracao,Ativo,Email,TelefoneFixo,TelefoneMovel,Endereco,Pais_Id,Estado_Id,Municipio_Id,Bairro_Id,Logradouro_Id,Cep,Numero,Complemento")] PESSOAS Candidato)
        {
            var erro = new CandidatoValidate().Validacao(Candidato);

            if (ModelState.IsValid && erro == "")
            {                
                Candidato.Id = Candidato.GetHashCode();
                Candidato.Tipo = 1;
                db.PESSOAS.Add(Candidato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Error = erro; 
            ViewBag.Bairro_Id = new SelectList(db.BAIRROS, "Id", "Nome", Candidato.Bairro_Id);
            ViewBag.Estado_Id = new SelectList(db.ESTADOS, "Id", "Nome", Candidato.Estado_Id);
            ViewBag.Logradouro_Id = new SelectList(db.LOGRADOUROS, "Id", "Nome", Candidato.Logradouro_Id);
            ViewBag.Municipio_Id = new SelectList(db.MUNICIPIOS, "Id", "Nome", Candidato.Municipio_Id);
            ViewBag.Pais_Id = new SelectList(db.PAISES, "Id", "Nome", Candidato.Pais_Id);
            return View(Candidato);
        }

        // GET: Candidatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PESSOAS Candidato = db.PESSOAS.Find(id);
            if (Candidato == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bairro_Id = new SelectList(db.BAIRROS, "Id", "Nome", Candidato.Bairro_Id);
            ViewBag.Estado_Id = new SelectList(db.ESTADOS, "Id", "Nome", Candidato.Estado_Id);
            ViewBag.Logradouro_Id = new SelectList(db.LOGRADOUROS, "Id", "Nome", Candidato.Logradouro_Id);
            ViewBag.Municipio_Id = new SelectList(db.MUNICIPIOS, "Id", "Nome", Candidato.Municipio_Id);
            ViewBag.Pais_Id = new SelectList(db.PAISES, "Id", "Nome", Candidato.Pais_Id);
            return View(Candidato);
        }

        // POST: Candidatos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,DataNascimento,Cpf,Foto,DataCriacao,DataAlteracao,Ativo,Email,TelefoneFixo,TelefoneMovel,Endereco,Pais_Id,Estado_Id,Municipio_Id,Bairro_Id,Logradouro_Id,Cep,Numero,Complemento")] PESSOAS Candidato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Candidato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bairro_Id = new SelectList(db.BAIRROS, "Id", "Nome", Candidato.Bairro_Id);
            ViewBag.Estado_Id = new SelectList(db.ESTADOS, "Id", "Nome", Candidato.Estado_Id);
            ViewBag.Logradouro_Id = new SelectList(db.LOGRADOUROS, "Id", "Nome", Candidato.Logradouro_Id);
            ViewBag.Municipio_Id = new SelectList(db.MUNICIPIOS, "Id", "Nome", Candidato.Municipio_Id);
            ViewBag.Pais_Id = new SelectList(db.PAISES, "Id", "Nome", Candidato.Pais_Id);
            return View(Candidato);
        }

        // GET: Candidatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PESSOAS Candidato = db.PESSOAS.Find(id);
            if (Candidato == null)
            {
                return HttpNotFound();
            }
            return View(Candidato);
        }

        // POST: Candidatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PESSOAS Candidato = db.PESSOAS.Find(id);
            db.PESSOAS.Remove(Candidato);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
