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
    public class CandidatoCargoController : Controller
    {
        private PrismaEntities db = new PrismaEntities();

        // GET: CandidatoCargo
        public ActionResult Index()
        {
            var cANDIDATOCARGO = db.CANDIDATOCARGO.Include(c => c.CARGOS).Include(c => c.PESSOAS);
            return View(cANDIDATOCARGO.ToList());
        }

        // GET: CandidatoCargo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANDIDATOCARGO cANDIDATOCARGO = db.CANDIDATOCARGO.Find(id);
            if (cANDIDATOCARGO == null)
            {
                return HttpNotFound();
            }
            return View(cANDIDATOCARGO);
        }

        // GET: CandidatoCargo/Create
        public ActionResult Create(int Id)
        {
            ViewBag.Candidato_Id = db.PESSOAS.Where(p => p.Id == Id).FirstOrDefault();            
            ViewBag.Cargo_Id = new SelectList(db.CARGOS, "Id", "Nome");
            ViewBag.Candidato = new SelectList(db.PESSOAS, "Id", "nome");
            return View();
        }

        // POST: CandidatoCargo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Candidato_Id,Cargo_Id,DataCriacao")] CANDIDATOCARGO cANDIDATOCARGO)
        {
            cANDIDATOCARGO.Id = GetHashCode();
            if (ModelState.IsValid)
            {
                db.CANDIDATOCARGO.Add(cANDIDATOCARGO);                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Candidato_Id = cANDIDATOCARGO.PESSOAS;
            ViewBag.Cargo_Id = new SelectList(db.CARGOS, "Id", "Nome", cANDIDATOCARGO.Cargo_Id);
            ViewBag.Candidato = new SelectList(db.PESSOAS, "Id", "nome", cANDIDATOCARGO.Candidato_Id);
            return View(cANDIDATOCARGO);
        }

        // GET: CandidatoCargo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANDIDATOCARGO cANDIDATOCARGO = db.CANDIDATOCARGO.Find(id);
            if (cANDIDATOCARGO == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cargo_Id = new SelectList(db.CARGOS, "Id", "Nome", cANDIDATOCARGO.Cargo_Id);
            ViewBag.Candidato_Id = new SelectList(db.PESSOAS, "Id", "nome", cANDIDATOCARGO.Candidato_Id);
            return View(cANDIDATOCARGO);
        }

        // POST: CandidatoCargo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Candidato_Id,Cargo_Id,DataCriacao")] CANDIDATOCARGO cANDIDATOCARGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cANDIDATOCARGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cargo_Id = new SelectList(db.CARGOS, "Id", "Nome", cANDIDATOCARGO.Cargo_Id);
            ViewBag.Candidato_Id = new SelectList(db.PESSOAS, "Id", "nome", cANDIDATOCARGO.Candidato_Id);
            return View(cANDIDATOCARGO);
        }

        // GET: CandidatoCargo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CANDIDATOCARGO cANDIDATOCARGO = db.CANDIDATOCARGO.Find(id);
            if (cANDIDATOCARGO == null)
            {
                return HttpNotFound();
            }
            return View(cANDIDATOCARGO);
        }

        // POST: CandidatoCargo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CANDIDATOCARGO cANDIDATOCARGO = db.CANDIDATOCARGO.Find(id);
            db.CANDIDATOCARGO.Remove(cANDIDATOCARGO);
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
