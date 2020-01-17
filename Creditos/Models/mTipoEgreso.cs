using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mTipoEgreso{
        public int id_tipo_egreso { get; set; }
        public string descripcion { get; set; }

        public mTipoEgreso() { }
        public mTipoEgreso(int id_tipo_egreso, string descripcion){
            this.id_tipo_egreso = id_tipo_egreso;
            this.descripcion = descripcion;
        }
    }
}