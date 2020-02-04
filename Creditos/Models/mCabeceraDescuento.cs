using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mCabeceraDescuento{
        public int id_cabecera_descuento { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> subdescuento_id { get; set; }
        public string subdescuento { get; set; }

        public mCabeceraDescuento() { }
        public mCabeceraDescuento(int id_cabecera_descuento, string descripcion, int subdescuento_id)
        {
            this.id_cabecera_descuento = id_cabecera_descuento;
            this.descripcion = descripcion;
            this.subdescuento_id = subdescuento_id;
        }
        public mCabeceraDescuento(int id_cabecera_descuento, string descripcion, string subdescuento)
        {
            this.id_cabecera_descuento = id_cabecera_descuento;
            this.descripcion = descripcion;
            this.subdescuento = subdescuento;
        }
    }
}