using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PrismaWEB.Dao;
using PrismaWEB.Models;

namespace PrismaWEB.Controllers
{
    public class CargosController : Controller
    {
        private readonly Cargos ctx = new Cargos();

        // GET: Cargos
        public ActionResult Index()
        {
            var a = View(ctx.Tudo());
            return a;
        }

        // GET: Cargos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cARGOS = ctx.BuscaPorId(id);
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
                ctx.Adicionar(cARGOS);
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
            Cargos cARGOS = ctx.BuscaPorId(id);
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
                ctx.Editar(Cargo);
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
            Cargos cARGOS = ctx.BuscaPorId(id);
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
            Cargos cARGOS = ctx.BuscaPorId(id);
            ctx.Deletar(cARGOS);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
