//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PrismaWEB.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Teste
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Nullable<int> Pessoa { get; set; }
        public Nullable<int> HeCarro { get; set; }
        public System.DateTime DataCriacao { get; set; }
        public System.DateTime DataNascimeno { get; set; }
    
        public virtual Pessoa Pessoa1 { get; set; }
    }
}
