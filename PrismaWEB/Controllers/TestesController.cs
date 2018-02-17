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
    public class TestesController : Controller
    {
        private TesteDBEntities1 db = new TesteDBEntities1();

        // GET: Testes
        public ActionResult Index()
        {
            var teste = db.Teste.Include(t => t.Pessoa1);
            return View(teste.ToList());
        }

        // GET: Testes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teste teste = db.Teste.Find(id);
            if (teste == null)
            {
                return HttpNotFound();
            }
            return View(teste);
        }

        // GET: Testes/Create
        public ActionResult Create()
        {
            ViewBag.Pessoa = new SelectList(db.Pessoa, "Id", "Nome");
            return View();
        }

        // POST: Testes/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Pessoa,HeCarro,DataCriacao,DataNascimeno")] Teste teste)
        {
            if (ModelState.IsValid)
            {
                db.Teste.Add(teste);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pessoa = new SelectList(db.Pessoa, "Id", "Nome", teste.Pessoa);
            return View(teste);
        }

        // GET: Testes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teste teste = db.Teste.Find(id);
            if (teste == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pessoa = new SelectList(db.Pessoa, "Id", "Nome", teste.Pessoa);
            return View(teste);
        }

        // POST: Testes/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Pessoa,HeCarro,DataCriacao,DataNascimeno")] Teste teste)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teste).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pessoa = new SelectList(db.Pessoa, "Id", "Nome", teste.Pessoa);
            return View(teste);
        }

        // GET: Testes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teste teste = db.Teste.Find(id);
            if (teste == null)
            {
                return HttpNotFound();
            }
            return View(teste);
        }

        // POST: Testes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teste teste = db.Teste.Find(id);
            db.Teste.Remove(teste);
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
