using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mProveedor{
        public int id_proveedor { get; set; }
        public string persona_juridica { get; set; }
        public string RUC { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string email { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

        public mProveedor() { }
        public mProveedor(int id_proveedor, String persona_juridica, string RUC, string nombre, string descripcion, string email, string direccion, string telefono)
        {
            this.id_proveedor = id_proveedor;
            this.persona_juridica = persona_juridica;
            this.RUC = RUC;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.email = email;
            this.direccion = direccion;
            this.telefono = telefono;
        }
    }
}