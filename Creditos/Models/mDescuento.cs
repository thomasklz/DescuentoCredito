using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mDescuento{
        public int id_descuento { get; set; }
        public double valor { get; set; }
        public Nullable<int> empleado_id { get; set; }
        public Nullable<int> cab_desc_id { get; set; }
        public Nullable<int> mes_id { get; set; }
        public DateTime fecha { get; set; }
        public string persona { get; set; }
        public string cabecera { get; set; }
        public string mes { get; set; }

        public mDescuento() { }
        public mDescuento(int id_descuento, double valor, int empleado_id, int cab_desc_id, int mes_id, DateTime fecha){
            this.id_descuento = id_descuento;
            this.valor = valor;
            this.empleado_id = empleado_id;
            this.cab_desc_id = cab_desc_id;
            this.mes_id = mes_id;
            this.fecha = fecha;

        }
        public mDescuento(int id_descuento, double valor, string persona, string cabecera, string mes, DateTime fecha, string prueba){
            this.id_descuento = id_descuento;
            this.valor = valor;
            this.persona = persona;
            this.cabecera = cabecera;
            this.mes = mes;
            this.fecha = fecha;

        }
    }
}