using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mValorUtilizado{
        public int id_valor_usad { get; set; }
        public Nullable<int> valor_asig_id { get; set; }
        public Nullable<int> mes_id { get; set; }
        public double cantidad_usada { get; set; }
        public string persona { get; set; }
        public string proveedor { get; set; }
        public string mes { get; set; }
        public double cantidad_aprobada { get; set; }
        public string aso { get; set; }

        public mValorUtilizado() { }
        public mValorUtilizado(int id_valor_usad, int valor_asig_id, int mes_id, double cantidad_usada)
        {
            this.id_valor_usad = id_valor_usad;
            this.valor_asig_id = valor_asig_id;
            this.mes_id = mes_id;
            this.cantidad_usada = cantidad_usada;
        }
        public mValorUtilizado(int id_valor_usad, string persona, string proveedor, string mes, double cantidad_usada, double cantidad_aprobada)
        {
            this.id_valor_usad = id_valor_usad;
            this.persona = persona;
            this.proveedor = proveedor;
            this.mes = mes;
            this.cantidad_usada = cantidad_usada;
            this.cantidad_aprobada = cantidad_aprobada;

        }
        public mValorUtilizado(int id_valor_usad, string aso, int valor_asig_id, string persona, string mes, double cantidad_aprobada, double cantidad_usada){
            this.id_valor_usad = id_valor_usad;
            this.aso = aso;
            this.valor_asig_id = valor_asig_id;
            this.persona = persona;
            this.mes = mes;
            this.cantidad_aprobada = cantidad_aprobada;
            this.cantidad_usada = cantidad_usada;
        }
        public mValorUtilizado(int id_valor_usad, int valor_asig_id, string persona, int mes_id, double cantidad_aprobada, double cantidad_usada)
        {
            this.id_valor_usad = id_valor_usad;
            this.valor_asig_id = valor_asig_id;
            this.persona = persona;
            this.mes_id = mes_id;
            this.cantidad_aprobada = cantidad_aprobada;
            this.cantidad_usada = cantidad_usada;
        }
    }
}