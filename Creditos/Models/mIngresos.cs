using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mIngresos{
        public int id_ingresos { get; set; }
        public double valor { get; set; }
        public Nullable<int> asociacion_id { get; set; }
        public Nullable<int> tipo_ingreso_id { get; set; }
        public Nullable<int> mes_id { get; set; }
        public string mes { get; set; }
        public string  tipoingreso { get; set; }
        public double sum { get; set; }

        public mIngresos() { }
        public mIngresos(int id_ingresos, double valor, int asociacion_id, int tipo_ingreso_id, int mes_id){
            this.id_ingresos = id_ingresos;
            this.valor = valor;
            this.asociacion_id = asociacion_id;
            this.tipo_ingreso_id = tipo_ingreso_id;
            this.mes_id = mes_id;
        }

        public mIngresos(int id_ingresos, double valor, string tipoingreso, string mes)
        {
            this.id_ingresos = id_ingresos;
            this.valor = valor;
            this.tipoingreso = tipoingreso;
            this.mes = mes;
        }
        public mIngresos( double sum, int mes_id, string mes){
            this.sum = sum;
            this.mes_id = mes_id;
            this.mes = mes;
        }
        public mIngresos(int id_ingresos, double valor, int tipo_ingreso_id, int mes_id)
        {
            this.id_ingresos = id_ingresos;
            this.valor = valor;
            this.tipo_ingreso_id = tipo_ingreso_id;
            this.mes_id = mes_id;
        }
    }
}