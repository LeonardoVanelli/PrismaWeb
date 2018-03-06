using PrismaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrismaWEB.Controllers
{
    public class CbControllerController : Controller
    {
        private PrismaEntities db = new PrismaEntities();
        // GET: CbController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Localizacao()
        {
            ViewBag.Pais_Id = new SelectList(db.PAISES, "Id", "Nome");
            return View();
        }
    }
}