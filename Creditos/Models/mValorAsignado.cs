using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mValorAsignado{
        public int id_valor_asig { get; set; }
        public int proveedor_id { get; set; }
        public int aso_id { get; set; }
        public int empleado_id { get; set; }
        public float monto_aprobado { get; set; }

        public mValorAsignado() { }
        public mValorAsignado(int id_valor_asig, int proveedor_id, int aso_id, int empleado_id, float monto_aprobado)
        {
            this.id_valor_asig = id_valor_asig;
            this.proveedor_id = proveedor_id;
            this.aso_id = aso_id;
            this.empleado_id = empleado_id;
            this.monto_aprobado = monto_aprobado;
        }
    }
}