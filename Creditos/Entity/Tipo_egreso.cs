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
    
    public partial class Tipo_egreso
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tipo_egreso()
        {
            this.Egresos = new HashSet<Egresos>();
        }
    
        public int id_tipo_egreso { get; set; }
        public string descripcion { get; set; }
        public Nullable<bool> est_delete { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Egresos> Egresos { get; set; }
    }
}
