using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsProveedor{
        Roles_Creditos_BDEntities db = new Roles_Creditos_BDEntities();
        public List<mProveedor> mostrar(){
            List<mProveedor> lista_proveedor = new List<mProveedor>();
            foreach (var item in db.spConsultarProveedor()){
                lista_proveedor.Add(new mProveedor(item.id_proveedor, Convert.ToString(item.persona_juridica), Convert.ToString(item.RUC), Convert.ToString(item.nombre), Convert.ToString(item.descripcion), Convert.ToString(item.email), Convert.ToString(item.direccion), Convert.ToString(item.telefono)));
            }
            return lista_proveedor;
        }
        public void ingresar(mProveedor datos){
            db.spInsertarProveedor(datos.persona_juridica, datos.RUC, datos.nombre, datos.descripcion, datos.email, datos.direccion, datos.telefono);
        }
        public void eliminar(mProveedor datos){
            db.spEliminarProveedor(datos.id_proveedor);
        }
        public void modificar(mProveedor datos){
            db.spModificarProveedor(datos.id_proveedor, datos.persona_juridica, datos.RUC, datos.nombre, datos.descripcion, datos.email, datos.direccion, datos.telefono);
        }
    }
}