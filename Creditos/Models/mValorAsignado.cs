using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mValorAsignado{
        public int id_valor_asig { get; set; }
        public Nullable<int> proveedor_id { get; set; }
        public Nullable<int> aso_id { get; set; }
        public Nullable<int> empleado_id { get; set; }
        public double monto_aprobado { get; set; }
        public string proveedor { get; set; }
        public string empleado { get; set; }

        public mValorAsignado() { }
        public mValorAsignado(int id_valor_asig, int proveedor_id, int aso_id, int empleado_id, double monto_aprobado)
        {
            this.id_valor_asig = id_valor_asig;
            this.proveedor_id = proveedor_id;
            this.aso_id = aso_id;
            this.empleado_id = empleado_id;
            this.monto_aprobado = monto_aprobado;
        }
        public mValorAsignado(int id_valor_asig, string proveedor, string empleado, double monto_aprobado)
        {
            this.id_valor_asig = id_valor_asig;
            this.proveedor = proveedor;
            this.empleado = empleado;
            this.monto_aprobado = monto_aprobado;
        }
        public mValorAsignado(int id_valor_asig, string proveedor, int proveedor_id, string empleado,int empleado_id, double monto_aprobado)
        {
            this.id_valor_asig = id_valor_asig;
            this.proveedor = proveedor;
            this.proveedor_id = proveedor_id;
            this.empleado = empleado;
            this.empleado_id = empleado_id;
            this.monto_aprobado = monto_aprobado;
        }
        public mValorAsignado(int id_valor_asig, int proveedor_id, int empleado_id, double monto_aprobado)
        {
            this.id_valor_asig = id_valor_asig;
            this.proveedor_id = proveedor_id;
            this.empleado_id = empleado_id;
            this.monto_aprobado = monto_aprobado;
        }
    }
}