using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mSubDescuentos
    {
        public int id_subdescuento { get; set; }
        public string descripcion { get; set; }

        public mSubDescuentos() { }
        public mSubDescuentos(int id_subdescuento, string descripcion)
        {
            this.id_subdescuento = id_subdescuento;
            this.descripcion = descripcion;
        }
    }
}





