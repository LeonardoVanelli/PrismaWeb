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
    public class VotoCandidatoController : Controller
    {
        private PrismaDBEntities db = new PrismaDBEntities();

        // GET: VotoCandidato
        public ActionResult Index(int id)
        {
            ViewBag.Candidato = id;
            var votocandidatolei = db.Votocandidatolei.Where(v => v.Candidato_Id == id);
            return View(votocandidatolei.ToList());
        }

        // GET: VotoCandidato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Votocandidatolei votocandidatolei = db.Votocandidatolei.Find(id);
            if (votocandidatolei == null)
            {
                return HttpNotFound();
            }
            return View(votocandidatolei);
        }

        // GET: VotoCandidato/Create
        public ActionResult Create(int id)
        {
            ViewBag.Lei_Id = db.Leis.SqlQuery($"Select * from Leis where Id not in (select Lei_Id from Votocandidatolei vcl where vcl.Candidato_Id = {id})");
            ViewBag.Candidato_Id = db.Pessoas.SqlQuery($"Select * from pessoas where Tipo = 1 and Id = {id}");
            return View();
        }

        // POST: VotoCandidato/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Candidato_Id,Lei_Id,Votou,DataCriacao")] Votocandidatolei votocandidatolei, string voto)
        {
            votocandidatolei.Id = GetHashCode();
            
            if (voto == "Não")            
                votocandidatolei.Votou = 0;
            else if(voto == "Sim")
                votocandidatolei.Votou = 1;

            votocandidatolei.DataCriacao = DateTime.Now;            
                
            if (ModelState.IsValid)
            {
                db.Votocandidatolei.Add(votocandidatolei);
                db.SaveChanges();
                return RedirectToAction("Index/"+votocandidatolei.Candidato_Id);
            }

            ViewBag.Lei_Id = db.Leis.SqlQuery("Select * from Leis where Id not in (select Lei_Id from Votocandidatolei vcl where vcl.Candidato_Id = 23838894)");
            ViewBag.Candidato_Id = db.Pessoas.SqlQuery("Select * from pessoas where Tipo = 1");
            return View(votocandidatolei);
        }

        // GET: VotoCandidato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Votocandidatolei votocandidatolei = db.Votocandidatolei.Find(id);
            if (votocandidatolei == null)
            {
                return HttpNotFound();
            }
            ViewBag.Lei_Id = db.Leis.Where(l => l.Id == votocandidatolei.Lei_Id).FirstOrDefault();
            ViewBag.Candidato_Id = db.Pessoas.Where(p => p.Id == votocandidatolei.Pessoas.Id).FirstOrDefault();
            return View(votocandidatolei);
        }

        // POST: VotoCandidato/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Candidato_Id,Lei_Id,Votou,DataCriacao")] Votocandidatolei votocandidatolei, string voto)
        {
            if (voto == "Não")
                votocandidatolei.Votou = 0;
            else if (voto == "Sim")
                votocandidatolei.Votou = 1;

            if (ModelState.IsValid)
            {
                db.Entry(votocandidatolei).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index/"+votocandidatolei.Candidato_Id);
            }
            ViewBag.Lei_Id = db.Leis.Where(l => l.Id == votocandidatolei.Lei_Id).FirstOrDefault();
            ViewBag.Candidato_Id = db.Pessoas.Where(p => p.Id == votocandidatolei.Pessoas.Id).FirstOrDefault();
            return View(votocandidatolei);
        }

        // GET: VotoCandidato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Votocandidatolei votocandidatolei = db.Votocandidatolei.Find(id);
            if (votocandidatolei == null)
            {
                return HttpNotFound();
            }
            return View(votocandidatolei);
        }

        // POST: VotoCandidato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Votocandidatolei votocandidatolei = db.Votocandidatolei.Find(id);
            db.Votocandidatolei.Remove(votocandidatolei);
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
