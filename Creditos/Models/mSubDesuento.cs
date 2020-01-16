using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models{
    public class mSubDesuento{
        public int id_subdescuento { get; set; }
        public string descripcion { get; set; }

        public mSubDesuento() { }
        public mSubDesuento(int id_subdescuento, string descripcion){
            this.id_subdescuento = id_subdescuento;
            this.descripcion = descripcion;
        }
    }
}