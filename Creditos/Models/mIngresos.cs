using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mIngresos{
        public int id_ingresos { get; set; }
        public float valor { get; set; }
        public int asociacion_id { get; set; }
        public int tipo_egreso_id { get; set; }
        public int mes_id { get; set; }

        public mIngresos() { }
        public mIngresos(int id_ingresos, float valor, int asociacion_id, int tipo_egreso_id, int mes_id)
        {
            this.id_ingresos = id_ingresos;
            this.valor = valor;
            this.asociacion_id = asociacion_id;
            this.tipo_egreso_id = tipo_egreso_id;
            this.mes_id = mes_id;
        }
    }
}