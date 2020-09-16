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
        public double porcCom { get; set; }
        public DateTime fecha { get; set; }
        public string institucion { get; set; }
        public string tipo_cta { get; set; }
        public string nCedula { get; set; }
        public string personaCuenta { get; set; }
        public string ncuenta { get; set; }
        public double valo_pago { get; set; }

        public mAsociacionProveedor() { }
        public mAsociacionProveedor(int id_asoc_prov, int proveedor_id, int asociacion_id, DateTime fecha, double porcCom)
        {
            this.id_asoc_prov = id_asoc_prov;
            this.proveedor_id = proveedor_id;
            this.asociacion_id = asociacion_id;
            this.fecha = fecha;
            this.porcCom = porcCom;
        }
        public mAsociacionProveedor(int id_asoc_prov, int proveedor_id, string proveedor, int asociacion_id, DateTime fecha, double porcCom)
        {
            this.id_asoc_prov = id_asoc_prov;
            this.proveedor_id = proveedor_id;
            this.proveedor = proveedor;
            this.asociacion_id = asociacion_id;
            this.fecha = fecha;
            this.porcCom = porcCom;
        }
        public mAsociacionProveedor(int id_asoc_prov, string proveedor, string aso, DateTime fecha, double porcCom)
        {
            this.id_asoc_prov = id_asoc_prov;
            this.proveedor = proveedor;
            this.aso = aso;
            this.fecha = fecha;
            this.porcCom = porcCom;
        }
        public mAsociacionProveedor(int id_asoc_prov, string proveedor, DateTime fecha)
        {
            this.id_asoc_prov = id_asoc_prov;
            this.proveedor = proveedor;
            this.fecha = fecha;
        }
        public mAsociacionProveedor(int id_asoc_prov, string proveedor, int proveedor_id, string aso, DateTime fecha, double porcCom)
        {
            this.id_asoc_prov = id_asoc_prov;
            this.proveedor = proveedor;
            this.proveedor_id = proveedor_id;
            this.aso = aso;
            this.fecha = fecha;
            this.porcCom = porcCom;
        }
        public mAsociacionProveedor(int id_asoc_prov, string proveedor, string institucion, string tipo_cta, string nCedula, string personaCuenta, string ncuenta, double valo_pago)
        {
            this.id_asoc_prov = id_asoc_prov;
            this.proveedor = proveedor;
            this.institucion = institucion;
            this.tipo_cta = tipo_cta;
            this.nCedula = nCedula;
            this.personaCuenta = personaCuenta;
            this.ncuenta = ncuenta;
            this.valo_pago = valo_pago;
        }
    }
}