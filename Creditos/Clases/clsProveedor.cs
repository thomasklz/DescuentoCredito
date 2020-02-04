using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsProveedor{
        AdministracionAcademicaEntities db = new AdministracionAcademicaEntities();
        clsProveedor clspro = new clsProveedor();
        List<mProveedor> lista_proveedor = new List<mProveedor>();
        public List<mProveedor> mostrar(){
            foreach (var item in db.spConsultarProveedor()){
                lista_proveedor.Add(new mProveedor(item.id_proveedor, Convert.ToString(item.persona_juridica), Convert.ToString(item.RUC), Convert.ToString(item.nombre), Convert.ToString(item.descripcion), Convert.ToString(item.email), Convert.ToString(item.direccion), Convert.ToString(item.telefono)));
            }
            return lista_proveedor;
        }
        public void ingresar(mProveedor datos){
            db.spInsertarProveedor(datos.persona_juridica, datos.RUC, datos.nombre, datos.descripcion, datos.email, datos.direccion, datos.telefono);
        }
        public void eliminar(int id){
            db.spEliminarProveedor(id);
        }
        public Boolean modificar(mProveedor datos)
        {
            Boolean result = false;
            try
            {
                db.spModificarProveedor(datos.id_proveedor, datos.persona_juridica, datos.RUC, datos.nombre, datos.descripcion, datos.email, datos.direccion, datos.telefono);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public List<mProveedor> mostrarById(int id)
        {
            foreach (var item in db.spConsultarProveedorById(id))
            {
                prov.Add(new mProveedor(item.id_proveedor, item.persona_juridica, item.RUC, item.nombre, item.descripcion, item.email, item.direccion, item.telefono));
            }
            return prov;
        }
    }
}