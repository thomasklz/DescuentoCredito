using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mAsociacion{
        public int id_asociacion { get; set; }
        public string descripcion { get; set; }

        public mAsociacion() { }
        public mAsociacion(int id_asociacion, string descripcion)
        {
            this.id_asociacion = id_asociacion;
            this.descripcion = descripcion;
        }
    }
}