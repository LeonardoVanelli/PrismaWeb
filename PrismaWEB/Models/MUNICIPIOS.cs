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
    
    public partial class MUNICIPIOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MUNICIPIOS()
        {
            this.BAIRROS = new HashSet<BAIRROS>();
            this.LOGRADOUROS = new HashSet<LOGRADOUROS>();
            this.PESSOAS = new HashSet<PESSOAS>();
        }
    
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Pais_Id { get; set; }
        public int Estado_Id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BAIRROS> BAIRROS { get; set; }
        public virtual ESTADOS ESTADOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LOGRADOUROS> LOGRADOUROS { get; set; }
        public virtual PAISES PAISES { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PESSOAS> PESSOAS { get; set; }
    }
}