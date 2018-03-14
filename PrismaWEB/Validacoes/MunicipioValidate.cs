using PrismaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismaWEB.Validacoes
{
    public class MunicipioValidate
    {
        private PrismaDBEntiti db = new PrismaDBEntiti();
        public string Validacao(Cidades municipio)
        {
            //var erro = "";
            //var queryResult = db.Cidades.SqlQuery($"Select * from municipios m where nome = '{municipio.Nome}' and Estado_Id = {municipio.Cidad}");
            //if (queryResult.Count() > 0)
            //{
            //    erro = "Este Municipio ja esta cadastrado";
            //}
            return "";
        }
    }
}