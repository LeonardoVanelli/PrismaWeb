using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrismaWEB.Models;

namespace PrismaWEB.Controllers
{
    public class PessoasController : Controller
    {
        private PrismaEntities db = new PrismaEntities();

        // GET: Pessoas
        public ActionResult Index()
        {
            var pESSOAS = db.PESSOAS.Include(p => p.BAIRROS).Include(p => p.ESTADOS).Include(p => p.LOGRADOUROS).Include(p => p.MUNICIPIOS).Include(p => p.PAISES);
            return View(pESSOAS.ToList());
        }

        // GET: Pessoas/Details/5
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
            return View(pESSOAS);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            ViewBag.Bairro_Id = new SelectList(db.BAIRROS, "Id", "Nome");
            ViewBag.Estado_Id = new SelectList(db.ESTADOS, "Id", "Nome");
            ViewBag.Logradouro_Id = new SelectList(db.LOGRADOUROS, "Id", "Nome");
            ViewBag.Municipio_Id = new SelectList(db.MUNICIPIOS, "Id", "Nome");
            ViewBag.Pais_Id = new SelectList(db.PAISES, "Id", "Nome");
            return View();
        }

        // POST: Pessoas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,DataNascimento,Cpf,Foto,DataCriacao,DataAlteracao,Ativo,Email,TelefoneFixo,TelefoneMovel,Endereco,Pais_Id,Estado_Id,Municipio_Id,Bairro_Id,Logradouro_Id,Cep,Numero,Complemento")] PESSOAS pESSOAS)
        {
            if (ModelState.IsValid)
            {
                db.PESSOAS.Add(pESSOAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bairro_Id = new SelectList(db.BAIRROS, "Id", "Nome", pESSOAS.Bairro_Id);
            ViewBag.Estado_Id = new SelectList(db.ESTADOS, "Id", "Nome", pESSOAS.Estado_Id);
            ViewBag.Logradouro_Id = new SelectList(db.LOGRADOUROS, "Id", "Nome", pESSOAS.Logradouro_Id);
            ViewBag.Municipio_Id = new SelectList(db.MUNICIPIOS, "Id", "Nome", pESSOAS.Municipio_Id);
            ViewBag.Pais_Id = new SelectList(db.PAISES, "Id", "Nome", pESSOAS.Pais_Id);
            return View(pESSOAS);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.Bairro_Id = new SelectList(db.BAIRROS, "Id", "Nome", pESSOAS.Bairro_Id);
            ViewBag.Estado_Id = new SelectList(db.ESTADOS, "Id", "Nome", pESSOAS.Estado_Id);
            ViewBag.Logradouro_Id = new SelectList(db.LOGRADOUROS, "Id", "Nome", pESSOAS.Logradouro_Id);
            ViewBag.Municipio_Id = new SelectList(db.MUNICIPIOS, "Id", "Nome", pESSOAS.Municipio_Id);
            ViewBag.Pais_Id = new SelectList(db.PAISES, "Id", "Nome", pESSOAS.Pais_Id);
            return View(pESSOAS);
        }

        // POST: Pessoas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,DataNascimento,Cpf,Foto,DataCriacao,DataAlteracao,Ativo,Email,TelefoneFixo,TelefoneMovel,Endereco,Pais_Id,Estado_Id,Municipio_Id,Bairro_Id,Logradouro_Id,Cep,Numero,Complemento")] PESSOAS pESSOAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pESSOAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bairro_Id = new SelectList(db.BAIRROS, "Id", "Nome", pESSOAS.Bairro_Id);
            ViewBag.Estado_Id = new SelectList(db.ESTADOS, "Id", "Nome", pESSOAS.Estado_Id);
            ViewBag.Logradouro_Id = new SelectList(db.LOGRADOUROS, "Id", "Nome", pESSOAS.Logradouro_Id);
            ViewBag.Municipio_Id = new SelectList(db.MUNICIPIOS, "Id", "Nome", pESSOAS.Municipio_Id);
            ViewBag.Pais_Id = new SelectList(db.PAISES, "Id", "Nome", pESSOAS.Pais_Id);
            return View(pESSOAS);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int? id)
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
            return View(pESSOAS);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PESSOAS pESSOAS = db.PESSOAS.Find(id);
            db.PESSOAS.Remove(pESSOAS);
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
