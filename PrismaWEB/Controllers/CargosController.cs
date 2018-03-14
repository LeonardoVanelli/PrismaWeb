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
    public class CargosController : Controller
    {
        private PrismaBDEntities db = new PrismaBDEntities();

        // GET: Cargos
        public ActionResult Index()
        {
            return View(db.Cargos.ToList());
        }

        // GET: Cargos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargos cARGOS = db.Cargos.Find(id);
            if (cARGOS == null)
            {
                return HttpNotFound();
            }
            return View(cARGOS);
        }

        // GET: Cargos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cargos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,DataCraicao,DataAlteracao")] Cargos cARGOS)
        {
            cARGOS.Id = cARGOS.GetHashCode();
            cARGOS.DataCraicao = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Cargos.Add(cARGOS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cARGOS);
        }

        // GET: Cargos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargos cARGOS = db.Cargos.Find(id);
            if (cARGOS == null)
            {
                return HttpNotFound();
            }
            return View(cARGOS);
        }

        // POST: Cargos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cargos Cargo)
        {
            if (ModelState.IsValid)
            {            
                Cargo.DataAlteracao = DateTime.Now;
                db.Entry(Cargo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Cargo);
        }

        // GET: Cargos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cargos cARGOS = db.Cargos.Find(id);
            if (cARGOS == null)
            {
                return HttpNotFound();
            }
            return View(cARGOS);
        }

        // POST: Cargos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cargos cARGOS = db.Cargos.Find(id);
            db.Cargos.Remove(cARGOS);
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
