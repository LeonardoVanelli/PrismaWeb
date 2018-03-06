using PrismaWEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismaWEB.Validacoes
{
    public class MunicipioValidate
    {
        private PrismaEntities db = new PrismaEntities();
        public string Validacao(MUNICIPIOS municipio)
        {
            var erro = "";
            var queryResult = db.MUNICIPIOS.SqlQuery($"Select * from municipios m where nome = '{municipio.Nome}' and Estado_Id = {municipio.Estado_Id}");
            if (queryResult.Count() > 0)
            {
                erro = "Este Municipio ja esta cadastrado";
            }
            return erro;
        }
    }
}