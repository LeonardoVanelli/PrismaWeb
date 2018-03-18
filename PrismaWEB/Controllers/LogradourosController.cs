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
    public class LogradourosController : Controller
    {
        private PrismaDBEntities db = new PrismaDBEntities();

        // GET: Logradouros
        public ActionResult Index()
        {
            var logradouros = db.Logradouros.Include(l => l.Bairros).Include(l => l.Cidades).Include(l => l.Estados).Include(l => l.Paises);
            return View(logradouros.ToList());
        }

        // GET: Logradouros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logradouros logradouros = db.Logradouros.Find(id);
            if (logradouros == null)
            {
                return HttpNotFound();
            }
            return View(logradouros);
        }

        // GET: Logradouros/Create
        public ActionResult Create()
        {
            ViewBag.Bairro = new SelectList(db.Bairros, "Id", "Nome");
            ViewBag.Cidade = new SelectList(db.Cidades, "Id", "Nome");
            ViewBag.Estado = new SelectList(db.Estados, "Id", "Nome");
            ViewBag.Pais = new SelectList(db.Paises, "Id", "Nome");
            return View();
        }

        // POST: Logradouros/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Bairro,Cidade,Estado,Pais")] Logradouros logradouros)
        {
            if (ModelState.IsValid)
            {
                db.Logradouros.Add(logradouros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bairro = new SelectList(db.Bairros, "Id", "Nome", logradouros.Bairro);
            ViewBag.Cidade = new SelectList(db.Cidades, "Id", "Nome", logradouros.Cidade);
            ViewBag.Estado = new SelectList(db.Estados, "Id", "Nome", logradouros.Estado);
            ViewBag.Pais = new SelectList(db.Paises, "Id", "Nome", logradouros.Pais);
            return View(logradouros);
        }

        // GET: Logradouros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logradouros logradouros = db.Logradouros.Find(id);
            if (logradouros == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bairro = new SelectList(db.Bairros, "Id", "Nome", logradouros.Bairro);
            ViewBag.Cidade = new SelectList(db.Cidades, "Id", "Nome", logradouros.Cidade);
            ViewBag.Estado = new SelectList(db.Estados, "Id", "Nome", logradouros.Estado);
            ViewBag.Pais = new SelectList(db.Paises, "Id", "Nome", logradouros.Pais);
            return View(logradouros);
        }

        // POST: Logradouros/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Bairro,Cidade,Estado,Pais")] Logradouros logradouros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(logradouros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bairro = new SelectList(db.Bairros, "Id", "Nome", logradouros.Bairro);
            ViewBag.Cidade = new SelectList(db.Cidades, "Id", "Nome", logradouros.Cidade);
            ViewBag.Estado = new SelectList(db.Estados, "Id", "Nome", logradouros.Estado);
            ViewBag.Pais = new SelectList(db.Paises, "Id", "Nome", logradouros.Pais);
            return View(logradouros);
        }

        // GET: Logradouros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Logradouros logradouros = db.Logradouros.Find(id);
            if (logradouros == null)
            {
                return HttpNotFound();
            }
            return View(logradouros);
        }

        // POST: Logradouros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Logradouros logradouros = db.Logradouros.Find(id);
            db.Logradouros.Remove(logradouros);
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
