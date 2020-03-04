using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mAsociacionProveedor{
        public int id_asoc_prov { get; set; }
        public Nullable<int> proveedor_id { get; set; }
        public Nullable<int> asociacion_id { get; set; }
        public string aso { get; set; }
        public string proveedor { get; set; }
        public DateTime fecha { get; set; }

        public mAsociacionProveedor() { }
        public mAsociacionProveedor(int id_asoc_prov, int proveedor_id, int asociacion_id, DateTime fecha)
        {
            this.id_asoc_prov = id_asoc_prov;
            this.proveedor_id = proveedor_id;
            this.asociacion_id = asociacion_id;
            this.fecha = fecha;
        }
        public mAsociacionProveedor(int id_asoc_prov, string proveedor, string aso, DateTime fecha)
        {
            this.id_asoc_prov = id_asoc_prov;
            this.proveedor = proveedor;
            this.aso = aso;
            this.fecha = fecha;
        }
        public mAsociacionProveedor(int id_asoc_prov, string proveedor, int proveedor_id, string aso, DateTime fecha)
        {
            this.id_asoc_prov = id_asoc_prov;
            this.proveedor = proveedor;
            this.proveedor_id = proveedor_id;
            this.aso = aso;
            this.fecha = fecha;
        }
    }
}