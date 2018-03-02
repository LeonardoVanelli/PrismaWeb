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
    public class PaisesController : Controller
    {
        private PrismaEntities db = new PrismaEntities();

        // GET: Paises
        public ActionResult Index()
        {
            return View(db.PAISES.ToList());
        }

        // GET: Paises/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAISES pAISES = db.PAISES.Find(id);
            if (pAISES == null)
            {
                return HttpNotFound();
            }
            return View(pAISES);
        }

        // GET: Paises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paises/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] PAISES pAISES)
        {
            if (ModelState.IsValid)
            {
                db.PAISES.Add(pAISES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pAISES);
        }

        // GET: Paises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAISES pAISES = db.PAISES.Find(id);
            if (pAISES == null)
            {
                return HttpNotFound();
            }
            return View(pAISES);
        }

        // POST: Paises/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] PAISES pAISES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pAISES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pAISES);
        }

        // GET: Paises/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PAISES pAISES = db.PAISES.Find(id);
            if (pAISES == null)
            {
                return HttpNotFound();
            }
            return View(pAISES);
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PAISES pAISES = db.PAISES.Find(id);
            db.PAISES.Remove(pAISES);
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
