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
    
    public partial class Cabecera_Descuento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cabecera_Descuento()
        {
            this.Descuento = new HashSet<Descuento>();
        }
    
        public int id_cabecera_descuento { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> subdescuento_id { get; set; }
        public Nullable<bool> est_delete { get; set; }
    
        public virtual SubDescuento SubDescuento { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Descuento> Descuento { get; set; }
    }
}
