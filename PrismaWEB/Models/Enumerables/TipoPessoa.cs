using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismaWEB.Models.Enumerables
{
    public class TipoPessoa
    {
        public enum Tipos
        {
            Candidato = 1,
            Funcionario = 2,
            Usuario = 3
        }
        public Tipos Tipo { get; set; }
        
    }
}