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
    public class FuncionariosController : Controller
    {
        private PrismaDBEntities db = new PrismaDBEntities();

        // GET: Funcionarios
        public ActionResult Index()
        {
            var pessoas = db.Pessoas.Where(p => p.Tipo == 2);
            return View(pessoas.ToList());
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            ViewBag.Bairro_Id = new SelectList(db.Bairros, "Id", "Nome");
            ViewBag.Cidade_Id = new SelectList(db.Cidades, "Id", "Nome");
            ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome");
            ViewBag.Logradouro_Id = new SelectList(db.Logradouros, "Id", "Nome");
            ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome");
            return View();
        }

        // POST: Funcionarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,DataNascimento,Cpf,Foto,DataCriacao,DataAlteracao,Ativo,Email,TelefoneFixo,TelefoneMovel,Endereco,Pais_Id,Estado_Id,Cidade_Id,Bairro_Id,Logradouro_Id,Cep,Numero,Complemento,Tipo")] Pessoas pessoas)
        {
            pessoas.Id = GetHashCode();
            pessoas.Tipo = 2;
            if (ModelState.IsValid)
            {
                db.Pessoas.Add(pessoas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Bairro_Id = new SelectList(db.Bairros, "Id", "Nome", pessoas.Bairro_Id);
            ViewBag.Cidade_Id = new SelectList(db.Cidades, "Id", "Nome", pessoas.Cidade_Id);
            ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome", pessoas.Estado_Id);
            ViewBag.Logradouro_Id = new SelectList(db.Logradouros, "Id", "Nome", pessoas.Logradouro_Id);
            ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome", pessoas.Pais_Id);
            return View(pessoas);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            ViewBag.Bairro_Id = new SelectList(db.Bairros, "Id", "Nome", pessoas.Bairro_Id);
            ViewBag.Cidade_Id = new SelectList(db.Cidades, "Id", "Nome", pessoas.Cidade_Id);
            ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome", pessoas.Estado_Id);
            ViewBag.Logradouro_Id = new SelectList(db.Logradouros, "Id", "Nome", pessoas.Logradouro_Id);
            ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome", pessoas.Pais_Id);
            return View(pessoas);
        }

        // POST: Funcionarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,DataNascimento,Cpf,Foto,DataCriacao,DataAlteracao,Ativo,Email,TelefoneFixo,TelefoneMovel,Endereco,Pais_Id,Estado_Id,Cidade_Id,Bairro_Id,Logradouro_Id,Cep,Numero,Complemento,Tipo")] Pessoas pessoas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pessoas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Bairro_Id = new SelectList(db.Bairros, "Id", "Nome", pessoas.Bairro_Id);
            ViewBag.Cidade_Id = new SelectList(db.Cidades, "Id", "Nome", pessoas.Cidade_Id);
            ViewBag.Estado_Id = new SelectList(db.Estados, "Id", "Nome", pessoas.Estado_Id);
            ViewBag.Logradouro_Id = new SelectList(db.Logradouros, "Id", "Nome", pessoas.Logradouro_Id);
            ViewBag.Pais_Id = new SelectList(db.Paises, "Id", "Nome", pessoas.Pais_Id);
            return View(pessoas);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoas pessoas = db.Pessoas.Find(id);
            if (pessoas == null)
            {
                return HttpNotFound();
            }
            return View(pessoas);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoas pessoas = db.Pessoas.Find(id);
            db.Pessoas.Remove(pessoas);
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
