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
    
    public partial class Sobrante
    {
        public int id_sobrante { get; set; }
        public Nullable<int> descuento_id { get; set; }
        public Nullable<double> valor { get; set; }
        public Nullable<bool> estado { get; set; }
        public Nullable<bool> est_delete { get; set; }
    
        public virtual Descuento Descuento { get; set; }
    }
}
