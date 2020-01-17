using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mTipoIngreso{
        public int id_tipo_ingreso { get; set; }
        public string descripcion { get; set; }

        public mTipoIngreso() { }
        public mTipoIngreso(int id_tipo_ingreso, string descripcion)
        {
            this.id_tipo_ingreso = id_tipo_ingreso;
            this.descripcion = descripcion;
        }
    }
}