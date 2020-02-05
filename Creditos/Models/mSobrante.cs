using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mSobrante{
        private double v1;
        private double? descuento1;
        private bool v2;

        public int id_sobrante { get; set; }
        public Nullable<int> descuento_id { get; set; }
        public double valor { get; set; }
        public Boolean estado { get; set; }
        public double descuento { get; set; }


        public mSobrante() { }
        public mSobrante(int id_sobrante, double valor, int descuento_id, Boolean estado){
            this.id_sobrante = id_sobrante;
            this.descuento_id = descuento_id;
            this.valor = valor;
            this.estado = estado;
        }
        public mSobrante(int id_sobrante, double valor, double descuento, Boolean estado){
            this.id_sobrante = id_sobrante;
            this.descuento = descuento;
            this.valor = valor;
            this.estado = estado;
        }

        public mSobrante(int id_sobrante, double v1, double? descuento1, bool v2)
        {
            this.id_sobrante = id_sobrante;
            this.v1 = v1;
            this.descuento1 = descuento1;
            this.v2 = v2;
        }
    }
}