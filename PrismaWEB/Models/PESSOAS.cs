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
    using System.ComponentModel.DataAnnotations;

    public partial class Pessoas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pessoas()
        {
            this.Candidatocargo = new HashSet<Candidatocargo>();
            this.Favoritos = new HashSet<Favoritos>();
            this.Favoritos1 = new HashSet<Favoritos>();
            this.Presidentes = new HashSet<Presidentes>();
            this.Presidentes1 = new HashSet<Presidentes>();
            this.Votocandidatolei = new HashSet<Votocandidatolei>();
            this.Votos = new HashSet<Votos>();
            this.Votos1 = new HashSet<Votos>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public Nullable<System.DateTime> DataNascimento { get; set; }
        public string Cpf { get; set; }
        public string Foto { get; set; }
        public Nullable<System.DateTime> DataCriacao { get; set; }
        public Nullable<System.DateTime> DataAlteracao { get; set; }
        public Nullable<int> Ativo { get; set; }
        public string Email { get; set; }
        public string TelefoneFixo { get; set; }
        public string TelefoneMovel { get; set; }
        public string Endereco { get; set; }
        public Nullable<int> Pais_Id { get; set; }
        public Nullable<int> Estado_Id { get; set; }
        public Nullable<int> Cidade_Id { get; set; }
        public Nullable<int> Bairro_Id { get; set; }
        public Nullable<int> Logradouro_Id { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public Nullable<int> Tipo { get; set; }
    
        public virtual Bairros Bairros { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Candidatocargo> Candidatocargo { get; set; }
        public virtual Cidades Cidades { get; set; }
        public virtual Estados Estados { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favoritos> Favoritos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Favoritos> Favoritos1 { get; set; }
        public virtual Logradouros Logradouros { get; set; }
        public virtual Paises Paises { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Presidentes> Presidentes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Presidentes> Presidentes1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Votocandidatolei> Votocandidatolei { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Votos> Votos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Votos> Votos1 { get; set; }
    }
}
