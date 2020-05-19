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
        public Nullable<int> val_asig { get; set; }
        public Nullable<int> cab_desc_id { get; set; }
        public Nullable<int> mes_id { get; set; }
        public DateTime fecha { get; set; }
        public string persona { get; set; }
        public string cabecera { get; set; }
        public string mes { get; set; }
        public double sumatoria { get; set; }
        public double sobrant { get; set; }
        public string cedula { get; set; }

        public mDescuento() { }
        public mDescuento(int id_descuento, double valor, int empleado_id, int cab_desc_id, int mes_id, DateTime fecha){
            this.id_descuento = id_descuento;
            this.valor = valor;
            this.empleado_id = empleado_id;
            this.cab_desc_id = cab_desc_id;
            this.mes_id = mes_id;
            this.fecha = fecha;

        }
        public mDescuento(int id_descuento, double valor, string persona, string cabecera, string mes, DateTime fecha){
            this.id_descuento = id_descuento;
            this.valor = valor;
            this.persona = persona;
            this.cabecera = cabecera;
            this.mes = mes;
            this.fecha = fecha;
        }
        public mDescuento(int val_asig, double sumatoria, int Id_Persona, string persona, int id_asociacion, string aso, string mes, int id_mes, string Cedula){
            this.val_asig = val_asig;
            this.sumatoria = sumatoria;
            this.empleado_id = Id_Persona;
            this.persona = persona;
            this.cab_desc_id = id_asociacion;
            this.cabecera = aso;
            this.mes = mes;
            this.mes_id = id_mes;
            this.cedula = Cedula;
        }
        public mDescuento(int id_descuento, double sobrant, double valor, double sumatoria, int Id_Persona, string persona, int id_asociacion, string aso, string mes, int id_mes, DateTime fecha){
            this.id_descuento = id_descuento;
            this.sobrant = sobrant;
            this.valor = valor;
            this.sumatoria = sumatoria;
            this.empleado_id = Id_Persona;
            this.persona = persona;
            this.cab_desc_id = id_asociacion;
            this.cabecera = aso;
            this.mes = mes;
            this.mes_id = id_mes;
            this.fecha = fecha;
        }
    }
}