﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PrismaEntities : DbContext
    {
        public PrismaEntities()
            : base("name=PrismaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BAIRROS> BAIRROS { get; set; }
        public virtual DbSet<CANDIDATOCARGO> CANDIDATOCARGO { get; set; }
        public virtual DbSet<CARGOS> CARGOS { get; set; }
        public virtual DbSet<ESTADOS> ESTADOS { get; set; }
        public virtual DbSet<FAVORIOS> FAVORIOS { get; set; }
        public virtual DbSet<LEIS> LEIS { get; set; }
        public virtual DbSet<LOGRADOUROS> LOGRADOUROS { get; set; }
        public virtual DbSet<MUNICIPIOS> MUNICIPIOS { get; set; }
        public virtual DbSet<PAISES> PAISES { get; set; }
        public virtual DbSet<PESSOAS> PESSOAS { get; set; }
        public virtual DbSet<PRESIDENTES> PRESIDENTES { get; set; }
        public virtual DbSet<VOTOCANDIDATOLEI> VOTOCANDIDATOLEI { get; set; }
        public virtual DbSet<VOTOS> VOTOS { get; set; }
    }
}