using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mDescuento{
        public int id_descuento { get; set; }
        public double valor { get; set; }
        public int empleado_id { get; set; }
        public int cab_desc_id { get; set; }
        public int mes_id { get; set; }
        public DateTime fecha { get; set; }

        public mDescuento() { }
        public mDescuento(int id_descuento, double valor, int empleado_id, int cab_desc_id, int mes_id, DateTime fecha)
        {
            this.id_descuento = id_descuento;
            this.valor = valor;
            this.empleado_id = empleado_id;
            this.cab_desc_id = cab_desc_id;
            this.mes_id = mes_id;
            this.fecha = fecha;

        }
    }
}