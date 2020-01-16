using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mAsociacionProveedor{
        public int id_asoc_prov { get; set; }
        public int proveedor_id { get; set; }
        public int asociacion_id { get; set; }
        public DateTime fecha { get; set; }
        public Boolean est_delete { get; set; }

        public mAsociacionProveedor() { }
        public mAsociacionProveedor(int id_asoc_prov, int proveedor_id, int asociacion_id, DateTime fecha)
        {
            this.id_asoc_prov = id_asoc_prov;
            this.proveedor_id = proveedor_id;
            this.asociacion_id = asociacion_id;
            this.fecha = fecha;
        }
    }
}