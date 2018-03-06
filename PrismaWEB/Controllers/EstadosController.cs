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
    public class EstadosController : Controller
    {
        private PrismaEntities db = new PrismaEntities();

        // GET: Estados
        public ActionResult Index()
        {
            var eSTADOS = db.ESTADOS.Include(e => e.PAISES);
            return View(eSTADOS.ToList());
        }

        // GET: Estados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOS eSTADOS = db.ESTADOS.Find(id);
            if (eSTADOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Municipios = db.MUNICIPIOS.Where(m => m.Estado_Id == eSTADOS.Id);
            return View(eSTADOS);
        }

        // GET: Estados/Create
        public ActionResult Create()
        {
            ViewBag.Pais_Id = new SelectList(db.PAISES, "Id", "Nome");
            return View();
        }

        // POST: Estados/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Pais_Id")] ESTADOS eSTADOS)
        {
            if (ModelState.IsValid)
            {
                eSTADOS.Id = eSTADOS.GetHashCode();
                db.ESTADOS.Add(eSTADOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Pais_Id = new SelectList(db.PAISES, "Id", "Nome", eSTADOS.Pais_Id);
            return View(eSTADOS);
        }

        // GET: Estados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOS eSTADOS = db.ESTADOS.Find(id);
            if (eSTADOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Pais_Id = new SelectList(db.PAISES, "Id", "Nome", eSTADOS.Pais_Id);
            return View(eSTADOS);
        }

        // POST: Estados/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Pais_Id")] ESTADOS eSTADOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eSTADOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Pais_Id = new SelectList(db.PAISES, "Id", "Nome", eSTADOS.Pais_Id);
            return View(eSTADOS);
        }

        // GET: Estados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ESTADOS eSTADOS = db.ESTADOS.Find(id);
            if (eSTADOS == null)
            {
                return HttpNotFound();
            }
            return View(eSTADOS);
        }

        // POST: Estados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ESTADOS eSTADOS = db.ESTADOS.Find(id);
            db.ESTADOS.Remove(eSTADOS);
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
