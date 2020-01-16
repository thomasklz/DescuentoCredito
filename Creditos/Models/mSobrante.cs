using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mSobrante{
        public int id_sobrante { get; set; }
        public int descuento_id { get; set; }
        public float valor { get; set; }
        public Boolean estado { get; set; }
        public Boolean est_delete { get; set; }

        public mSobrante() { }
        public mSobrante(int id_sobrante, int descuento_id, float valor, Boolean estado){
            this.id_sobrante = id_sobrante;
            this.descuento_id = descuento_id;
            this.valor = valor;
            this.estado = estado;
        }
    }
}