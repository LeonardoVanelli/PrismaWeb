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
    public class AluguelsController : Controller
    {
        private LocadoraCarrosDBEntities db = new LocadoraCarrosDBEntities();

        // GET: Aluguels
        public ActionResult Index()
        {
            var aluguels = db.Aluguels.Include(a => a.Carroes).Include(a => a.Clientes).Include(a => a.Protecaos).Include(a => a.Status);
            return View(aluguels.ToList());
        }

        // GET: Aluguels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluguels aluguels = db.Aluguels.Find(id);
            if (aluguels == null)
            {
                return HttpNotFound();
            }
            return View(aluguels);
        }

        // GET: Aluguels/Create
        public ActionResult Create()
        {
            ViewBag.CarroId = new SelectList(db.Carroes, "Id", "Placa");
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            ViewBag.ProtecaoId = new SelectList(db.Protecaos, "Id", "Nome");
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Nome");
            return View();
        }

        // POST: Aluguels/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataHoraRetirada,DataHoraDevolucao,CarroId,ClienteId,ProtecaoId,StatusId")] Aluguels aluguels)
        {
            if (ModelState.IsValid)
            {
                db.Aluguels.Add(aluguels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CarroId = new SelectList(db.Carroes, "Id", "Placa", aluguels.CarroId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Cpf", aluguels.ClienteId);
            ViewBag.ProtecaoId = new SelectList(db.Protecaos, "Id", "Nome", aluguels.ProtecaoId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Nome", aluguels.StatusId);
            return View(aluguels);
        }

        // GET: Aluguels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluguels aluguels = db.Aluguels.Find(id);
            if (aluguels == null)
            {
                return HttpNotFound();
            }
            ViewBag.CarroId = new SelectList(db.Carroes, "Id", "Placa", aluguels.CarroId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Cpf", aluguels.ClienteId);
            ViewBag.ProtecaoId = new SelectList(db.Protecaos, "Id", "Nome", aluguels.ProtecaoId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Nome", aluguels.StatusId);
            return View(aluguels);
        }

        // POST: Aluguels/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataHoraRetirada,DataHoraDevolucao,CarroId,ClienteId,ProtecaoId,StatusId")] Aluguels aluguels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluguels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CarroId = new SelectList(db.Carroes, "Id", "Placa", aluguels.CarroId);
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Cpf", aluguels.ClienteId);
            ViewBag.ProtecaoId = new SelectList(db.Protecaos, "Id", "Nome", aluguels.ProtecaoId);
            ViewBag.StatusId = new SelectList(db.Status, "Id", "Nome", aluguels.StatusId);
            return View(aluguels);
        }

        // GET: Aluguels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluguels aluguels = db.Aluguels.Find(id);
            if (aluguels == null)
            {
                return HttpNotFound();
            }
            return View(aluguels);
        }

        // POST: Aluguels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluguels aluguels = db.Aluguels.Find(id);
            db.Aluguels.Remove(aluguels);
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
