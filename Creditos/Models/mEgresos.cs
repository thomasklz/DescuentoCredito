using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mEgresos{
        public int id_egresos { get; set; }
        public double valor { get; set; }
        public Nullable<int> asociacion_id { get; set; }
        public Nullable<int> tipo_egreso_id { get; set; }
        public Nullable<int> mes_id { get; set; }
        public string mes { get; set; }
        public string tipoegreso { get; set; }
        public double sum { get; set; }

        public mEgresos() { }
        public mEgresos(int id_egresos, double valor, int asociacion_id, int tipo_egreso_id, int mes_id){
            this.id_egresos = id_egresos;
            this.valor = valor;
            this.asociacion_id = asociacion_id;
            this.tipo_egreso_id = tipo_egreso_id;
            this.mes_id = mes_id;
        }
        public mEgresos(int id_egresos, double valor, string tipoegreso, string mes)
        {
            this.id_egresos = id_egresos;
            this.valor = valor;
            this.tipoegreso = tipoegreso;
            this.mes = mes;
        }
        public mEgresos(double sum, int mes_id, string mes)
        {
            this.sum = sum;
            this.mes_id = mes_id;
            this.mes = mes;
        }
        public mEgresos(int id_egresos, double valor, int tipo_egreso_id, int mes_id)
        {
            this.id_egresos = id_egresos;
            this.valor = valor;
            this.tipo_egreso_id = tipo_egreso_id;
            this.mes_id = mes_id;
        }
    }
}