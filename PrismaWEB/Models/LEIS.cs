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
    
    public partial class LEIS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LEIS()
        {
            this.VOTOCANDIDATOLEI = new HashSet<VOTOCANDIDATOLEI>();
        }
    
        public int Id { get; set; }
        public string Numero { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VOTOCANDIDATOLEI> VOTOCANDIDATOLEI { get; set; }
    }
}