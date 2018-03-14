using PrismaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PrismaWEB.Controllers
{
    public class SelectLocalizacaoController : Controller
    {
        private PrismaBDEntities db = new PrismaBDEntities();
        // GET: SelectLocalizacao
        public JsonResult RetornaEstados(int Id)
        {
            var estados = db.Estados.Where(m => m.Pais == Id).ToList();
            var obj = new List<object>();
            foreach (var item in estados)
            {
                obj.Add(new { name = item.Nome, value = item.Id }) ;
            }
            return Json(obj);
        }

        public JsonResult RetornaMunicipios(int Id)
        {
            var municipio = db.Cidades.Where(m => m.Estado == Id).ToList();
            var obj = new List<object>();
            foreach (var item in municipio)
            {
                obj.Add(new { name = item.Nome, value = item.Id });
            }
            return Json(obj);
        }
    }
}