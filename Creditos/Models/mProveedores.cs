using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mProveedores
    {
        public int id_proveedor { get; set; }
        public string persona_juridica { get; set; }
        public string RUC { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
        public string nCuenta { get; set; }
        public string nCedula { get; set; }
        public string personaCuenta { get; set; }
        public string aso { get; set; }
        public double porcCom { get; set; }
        public DateTime fecha { get; set; }
        public int id_aso_prov { get; set; }
        public int aso_id { get; set; }

        public mProveedores() { }
        public mProveedores(int id_proveedor, string persona_juridica, string RUC, string nombre, string descripcion, string email, string direccion, string telefono, string nCuenta, string nCedula, string personaCuenta){
            this.id_proveedor = id_proveedor;
            this.persona_juridica = persona_juridica;
            this.RUC = RUC;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.email = email;
            this.direccion = direccion;
            this.telefono = telefono;
            this.nCuenta = nCuenta;
            this.nCedula = nCedula;
            this.personaCuenta = personaCuenta;
        }
        public mProveedores(int id_proveedor, string persona_juridica, string RUC, string nombre, string descripcion, string email, string direccion, string telefono, string nCuenta, string nCedula, string personaCuenta, string aso, DateTime fecha, int id_aso_prov, int aso_id, double porcCom)
        {
            this.id_proveedor = id_proveedor;
            this.persona_juridica = persona_juridica;
            this.RUC = RUC;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.email = email;
            this.direccion = direccion;
            this.telefono = telefono;
            this.nCuenta = nCuenta;
            this.nCedula = nCedula;
            this.personaCuenta = personaCuenta;
            this.aso = aso;
            this.fecha = fecha;
            this.id_aso_prov = id_aso_prov;
            this.aso_id = aso_id;
            this.porcCom = porcCom;
        }
    }
}