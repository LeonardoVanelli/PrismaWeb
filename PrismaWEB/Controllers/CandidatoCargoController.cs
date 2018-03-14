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
        private PrismaBDEntities db = new PrismaBDEntities();

        // GET: CandidatoCargo
        public ActionResult Index()
        {
            var cANDIDATOCARGO = db.Candidatocargo.Include(c => c.Cargos).Include(c => c.Pessoas);
            return View(cANDIDATOCARGO.ToList());
        }

        // GET: CandidatoCargo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidatocargo cANDIDATOCARGO = db.Candidatocargo.Find(id);
            if (cANDIDATOCARGO == null)
            {
                return HttpNotFound();
            }
            return View(cANDIDATOCARGO);
        }

        // GET: CandidatoCargo/Create
        public ActionResult Create(int Id)
        {
            ViewBag.Candidato_Id = db.Pessoas.Where(p => p.Id == Id).FirstOrDefault();            
            ViewBag.Cargo_Id = new SelectList(db.Cargos, "Id", "Nome");
            ViewBag.Candidato = new SelectList(db.Pessoas, "Id", "nome");
            return View();
        }

        // POST: CandidatoCargo/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Candidato_Id,Cargo_Id,DataCriacao")] Candidatocargo cANDIDATOCARGO)
        {
            cANDIDATOCARGO.Id = GetHashCode();
            if (ModelState.IsValid)
            {
                db.Candidatocargo.Add(cANDIDATOCARGO);                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Candidato_Id = cANDIDATOCARGO.Pessoas;
            ViewBag.Cargo_Id = new SelectList(db.Cargos, "Id", "Nome", cANDIDATOCARGO.Cargo_Id);
            ViewBag.Candidato = new SelectList(db.Pessoas, "Id", "nome", cANDIDATOCARGO.Candidato_Id);
            return View(cANDIDATOCARGO);
        }

        // GET: CandidatoCargo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidatocargo cANDIDATOCARGO = db.Candidatocargo.Find(id);
            if (cANDIDATOCARGO == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cargo_Id = new SelectList(db.Cargos, "Id", "Nome", cANDIDATOCARGO.Cargo_Id);
            ViewBag.Candidato_Id = new SelectList(db.Pessoas, "Id", "nome", cANDIDATOCARGO.Candidato_Id);
            return View(cANDIDATOCARGO);
        }

        // POST: CandidatoCargo/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Candidato_Id,Cargo_Id,DataCriacao")] Candidatocargo cANDIDATOCARGO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cANDIDATOCARGO).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cargo_Id = new SelectList(db.Cargos, "Id", "Nome", cANDIDATOCARGO.Cargo_Id);
            ViewBag.Candidato_Id = new SelectList(db.Pessoas, "Id", "nome", cANDIDATOCARGO.Candidato_Id);
            return View(cANDIDATOCARGO);
        }

        // GET: CandidatoCargo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidatocargo cANDIDATOCARGO = db.Candidatocargo.Find(id);
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
            Candidatocargo cANDIDATOCARGO = db.Candidatocargo.Find(id);
            db.Candidatocargo.Remove(cANDIDATOCARGO);
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
