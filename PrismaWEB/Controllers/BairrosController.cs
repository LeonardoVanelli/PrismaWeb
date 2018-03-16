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
    public class BairrosController : Controller
    {
        private PrismaDBEntities db = new PrismaDBEntities();

        // GET: Bairros
        public ActionResult Index()
        {
            var Bairros = db.Bairros.Include(b => b.Cidades);            
            return View(Bairros.ToList());
        }

        // GET: Bairros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairros bAIRROS = db.Bairros.Find(id);
            if (bAIRROS == null)
            {
                return HttpNotFound();
            }
            return View(bAIRROS);
        }

        // GET: Bairros/Create
        public ActionResult Create()
        {
            ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome");
            ViewBag.Municipio_Id = new SelectList(db.Cidades, "Id", "Nome");
            ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome");
            return View();
        }

        // POST: Bairros/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Pais_Id,Estado_Id,Municipio_Id")] Bairros bAIRROS)
        {

            if (ModelState.IsValid)
            {
                bAIRROS.Id = bAIRROS.GetHashCode();
                db.Bairros.Add(bAIRROS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome", bAIRROS.Estado_Id);
            ViewBag.Municipio_Id = new SelectList(db.Cidades, "Id", "Nome", bAIRROS.Cidade);
            //ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome", bAIRROS.Pais_Id);
            return View(bAIRROS);
        }

        // GET: Bairros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairros bAIRROS = db.Bairros.Find(id);
            if (bAIRROS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome", bAIRROS.Estado);
            ViewBag.Municipio_Id = new SelectList(db.Cidades, "Id", "Nome", bAIRROS.Cidade);
            ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome", bAIRROS.Pais);
            return View(bAIRROS);
        }

        // POST: Bairros/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Pais,Estado,Cidade")] Bairros bAIRROS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bAIRROS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome", bAIRROS.Estado);
            ViewBag.Municipio_Id = new SelectList(db.Cidades, "Id", "Nome", bAIRROS.Cidade);
            ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome", bAIRROS.Pais);
            return View(bAIRROS);
        }

        // GET: Bairros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bairros bAIRROS = db.Bairros.Find(id);
            if (bAIRROS == null)
            {
                return HttpNotFound();
            }
            return View(bAIRROS);
        }

        // POST: Bairros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bairros bAIRROS = db.Bairros.Find(id);
            db.Bairros.Remove(bAIRROS);
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
