//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Creditos.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tipoContratoCargo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tipoContratoCargo()
        {
            this.Contrato = new HashSet<Contrato>();
        }
    
        public int idTipoContratoCargo { get; set; }
        public Nullable<int> idTipoContrato { get; set; }
        public Nullable<int> idCargo { get; set; }
        public Nullable<int> idsueldo { get; set; }
        public Nullable<bool> Eliminado { get; set; }
    
        public virtual Cargo Cargo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contrato> Contrato { get; set; }
        public virtual Sueldo Sueldo { get; set; }
        public virtual TipoContrato TipoContrato { get; set; }
    }
}
