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
    
    public partial class spConsultarCreditosNoAprobados_Result
    {
        public int id_credito { get; set; }
        public string descripcion { get; set; }
        public Nullable<double> cantidad { get; set; }
        public Nullable<System.DateTime> fecha_solicitud { get; set; }
        public Nullable<System.DateTime> fecha_aprobacion { get; set; }
        public Nullable<double> desc_mensual { get; set; }
        public Nullable<int> emp_aso_id { get; set; }
        public Nullable<int> numero_cuota { get; set; }
        public Nullable<bool> estado_activacion { get; set; }
        public Nullable<bool> estado_aprobacion { get; set; }
        public Nullable<bool> est_delete { get; set; }
        public string persona { get; set; }
        public string aso { get; set; }
        public int id_empl_aso { get; set; }
    }
}
