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
        private PrismaDBEntities db = new PrismaDBEntities();

        // GET: Candidatos
        public ActionResult Index()
        {
            var pESSOAS = db.Pessoas.Include(p => p.Bairros).Include(p => p.Estados).Include(p => p.Logradouros).Include(p => p.Cidades).Include(p => p.Paises).Where(m => m.Tipo ==1);
            return View(pESSOAS.ToList());
        }

        // GET: Candidatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pESSOAS = db.Pessoas.Find(id);
            if (pESSOAS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cargos = db.Cargos.SqlQuery($@"select * 
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
            ViewBag.Bairro_Id = new SelectList(db.Bairros, "Id", "Nome");
            ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome");
            ViewBag.Logradouro_Id = new SelectList(db.Logradouros, "Id", "Nome");
            ViewBag.Cidade_Id = new SelectList(db.Cidades, "Id", "Nome");
            ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome");
            ViewBag.Cargos = new SelectList(db.Cargos, "Id", "Nome");
            return View();
        }

        // POST: Candidatos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,DataNascimento,Cpf,Foto,DataCriacao,DataAlteracao,Ativo,Email,TelefoneFixo,TelefoneMovel,Endereco,Pais_Id,Estado_Id,Cidade_Id,Bairro_Id,Logradouro_Id,Cep,Numero,Complemento")] Pessoas Candidato)
        {
            var erro = new CandidatoValidate().Validacao(Candidato);
            Candidato.Id = Candidato.GetHashCode();
            Candidato.Tipo = 1;
            Candidato.DataCriacao = DateTime.Now;
            if (ModelState.IsValid && erro == "")
            {                
                db.Pessoas.Add(Candidato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Error = erro; 
            ViewBag.Bairro_Id = new SelectList(db.Bairros, "Id", "Nome", Candidato.Bairro_Id);
            ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome", Candidato.Estado_Id);
            ViewBag.Logradouro_Id = new SelectList(db.Logradouros, "Id", "Nome", Candidato.Logradouro_Id);
            ViewBag.Cidade_Id = new SelectList(db.Cidades, "Id", "Nome", Candidato.Cidade_Id);
            ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome", Candidato.Pais_Id);
            ViewBag.Cargos = new SelectList(db.Cargos, "Id", "Nome");
            return View(Candidato);
        }

        // GET: Candidatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas Candidato = db.Pessoas.Find(id);
            if (Candidato == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bairro_Id = new SelectList(db.Bairros, "Id", "Nome", Candidato.Bairro_Id);
            ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome", Candidato.Estado_Id);
            ViewBag.Logradouro_Id = new SelectList(db.Logradouros, "Id", "Nome", Candidato.Logradouro_Id);
            ViewBag.Municipio_Id = new SelectList(db.Cidades, "Id", "Nome", Candidato.Cidade_Id);
            ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome", Candidato.Pais_Id);
            return View(Candidato);
        }

        // POST: Candidatos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,DataNascimento,Cpf,Foto,DataCriacao,DataAlteracao,Ativo,Email,TelefoneFixo,TelefoneMovel,Endereco,Pais_Id,Estado_Id,Municipio_Id,Bairro_Id,Logradouro_Id,Cep,Numero,Complemento")] Pessoas Candidato)
        {
            Candidato.DataAlteracao = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(Candidato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bairro_Id = new SelectList(db.Bairros, "Id", "Nome", Candidato.Bairro_Id);
            ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome", Candidato.Estado_Id);
            ViewBag.Logradouro_Id = new SelectList(db.Logradouros, "Id", "Nome", Candidato.Logradouro_Id);
            ViewBag.Municipio_Id = new SelectList(db.Cidades, "Id", "Nome", Candidato.Cidade_Id);
            ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome", Candidato.Pais_Id);
            return View(Candidato);
        }

        // GET: Candidatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas Candidato = db.Pessoas.Find(id);
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
            Pessoas Candidato = db.Pessoas.Find(id);
            db.Pessoas.Remove(Candidato);
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
