using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mValorUtilizado{
        public int id_valor_usad { get; set; }
        public int valor_asig_id { get; set; }
        public int mes_id { get; set; }
        public float cantidad_usada { get; set; }

        public mValorUtilizado() { }
        public mValorUtilizado(int id_valor_usad, int valor_asig_id, int mes_id, float cantidad_usada){
            this.id_valor_usad = id_valor_usad;
            this.valor_asig_id = valor_asig_id;
            this.mes_id = mes_id;
            this.cantidad_usada = cantidad_usada;
        }
    }
}