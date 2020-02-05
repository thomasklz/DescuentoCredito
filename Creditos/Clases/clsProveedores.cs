using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;
namespace Creditos.Clases
{
    public class clsProveedores
    {
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        List<mProveedores> provee = new List<mProveedores>();
        public List<mProveedores> mostrar(){
            foreach (var item in db.spConsultarProveedor()){
                provee.Add(new mProveedores(item.id_proveedor, item.persona_juridica, item.RUC, item.nombre, item.descripcion, item.email, item.direccion, item.telefono));
            }
            return provee;
        }
        public void ingresar(mProveedores datos){
            db.spInsertarProveedor(datos.persona_juridica, datos.RUC, datos.nombre, datos.descripcion, datos.email, datos.direccion, datos.telefono);
        }
        public void eliminar(int id){
            db.spEliminarProveedor(id);
        }
        public Boolean modificar(mProveedores datos){
            Boolean result = false;
            try{
                db.spModificarProveedor(datos.id_proveedor, datos.persona_juridica, datos.RUC, datos.nombre, datos.descripcion, datos.email, datos.direccion, datos.telefono);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public List<mProveedores> mostrarById(int id){
            foreach (var item in db.spConsultarProveedorById(id)){
                provee.Add(new mProveedores(item.id_proveedor, item.persona_juridica, item.RUC, item.nombre, item.descripcion, item.email, item.direccion, item.telefono));
            }
            return provee;
        }
    }
}