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
    public class LeisController : Controller
    {
        private PrismaDBEntities db = new PrismaDBEntities();

        // GET: Leis
        public ActionResult Index()
        {
            return View(db.Leis.ToList());
        }

        // GET: Leis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leis leis = db.Leis.Find(id);
            if (leis == null)
            {
                return HttpNotFound();
            }
            return View(leis);
        }

        // GET: Leis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Leis/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numero,Nome,Descricao")] Leis leis)
        {
            leis.Id = GetHashCode();                        
            if (ModelState.IsValid)
            {
                db.Leis.Add(leis);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(leis);
        }

        // GET: Leis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leis leis = db.Leis.Find(id);
            if (leis == null)
            {
                return HttpNotFound();
            }
            return View(leis);
        }

        // POST: Leis/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numero,Nome,Descricao")] Leis leis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(leis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(leis);
        }

        // GET: Leis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Leis leis = db.Leis.Find(id);
            if (leis == null)
            {
                return HttpNotFound();
            }
            return View(leis);
        }

        // POST: Leis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Leis leis = db.Leis.Find(id);
            db.Leis.Remove(leis);
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
