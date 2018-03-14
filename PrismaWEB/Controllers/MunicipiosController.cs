using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrismaWEB.Models;
using PrismaWEB.Validacoes;

namespace PrismaWEB.Controllers
{
    public class MunicipiosController : Controller
    {
        private PrismaBDEntities db = new PrismaBDEntities();

        // GET: Municipios
        public ActionResult Index()
        {
            var mUNICIPIOS = db.Cidades.Include(m => m.Estados);
            return View(mUNICIPIOS.ToList());
        }

        // GET: Municipios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidades mUNICIPIOS = db.Cidades.Find(id);
            if (mUNICIPIOS == null)
            {
                return HttpNotFound();
            }
            return View(mUNICIPIOS);
        }

        // GET: Municipios/Create
        public ActionResult Create()
        {
            ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome");
            ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome");
            return View();
        }

        // POST: Municipios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Pais_Id,Estado_Id")] Cidades Municipio)
        {
            //var erro = new MunicipioValidate().Validacao(Municipio);
            if (ModelState.IsValid /*&& erro == ""*/)
            {
                db.Cidades.Add(Municipio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.Error = erro;
            ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome", Municipio.Estado);
            //ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome", Municipio.Pais_Id);
            return View(Municipio);
        }

        // GET: Municipios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidades mUNICIPIOS = db.Cidades.Find(id);
            if (mUNICIPIOS == null)
            {
                return HttpNotFound();
            }
            ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome", mUNICIPIOS.Estado);
            //ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome", mUNICIPIOS.Pais_Id);
            return View(mUNICIPIOS);
        }

        // POST: Municipios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Pais_Id,Estado_Id")] Cidades mUNICIPIOS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mUNICIPIOS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome", mUNICIPIOS.Estados);
            //ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome", mUNICIPIOS.Pais_Id);
            return View(mUNICIPIOS);
        }

        // GET: Municipios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidades mUNICIPIOS = db.Cidades.Find(id);
            if (mUNICIPIOS == null)
            {
                return HttpNotFound();
            }
            return View(mUNICIPIOS);
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cidades mUNICIPIOS = db.Cidades.Find(id);
            db.Cidades.Remove(mUNICIPIOS);
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
