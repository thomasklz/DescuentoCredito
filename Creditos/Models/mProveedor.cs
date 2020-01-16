using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Creditos.Models
{
    public class mProveedor{
        public int id_proveedor { get; set; }
        public String persona_juridica { get; set; }
        public String RUC { get; set; }
        public String nombre { get; set; }
        public String descripcion { get; set; }
        public String email { get; set; }
        public String direccion { get; set; }
        public String telefono { get; set; }

        public mProveedor() { }
        public mProveedor(int id_proveedor, String persona_juridica, String RUC, String nombre, String descripcion, String email, String direccion, String telefono)
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