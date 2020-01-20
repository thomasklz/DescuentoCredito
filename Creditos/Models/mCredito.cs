using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models{
    public class mCredito{
        public int id_credito{ get; set; }
        public string descripcion { get; set; }
        public double cantidad { get; set; }
        public DateTime fecha_solicitud { get; set; }
        public DateTime fecha_aprobacion { get; set; }
        public double desc_mensual { get; set; }
        public int emp_aso_id { get; set; }
        public int numero_cuota { get; set; }
        public Boolean estado_activacion { get; set; }
        public Boolean estado_aprobacion { get; set; }

        public mCredito() { }
        public mCredito(int id_credito, String descripcion, double cantidad, DateTime fecha_solicitud, DateTime fecha_aprobacion, double desc_mensual, int emp_aso_id, int numero_cuota, Boolean estado_activacion, Boolean estado_aprobacion)
        {
            this.id_credito = id_credito;
            this.descripcion = descripcion;
            this.cantidad = cantidad;
            this.fecha_solicitud = fecha_solicitud;
            this.fecha_aprobacion = fecha_aprobacion;
            this.desc_mensual = desc_mensual;
            this.emp_aso_id = emp_aso_id;
            this.numero_cuota = numero_cuota;
            this.estado_activacion = estado_activacion;
            this.estado_aprobacion = estado_aprobacion;
        }
    }
}