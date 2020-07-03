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
                provee.Add(new mProveedores(item.id_proveedor, item.persona_juridica, item.RUC, item.nombre, item.descripcion, item.email, item.direccion, item.telefono, item.nCuenta, item.nCedula, item.personaCuenta));
            }
            return provee;
        }
        public void ingresar(mProveedores datos){
            db.spInsertarProveedor(datos.persona_juridica, datos.RUC, datos.nombre, datos.descripcion, datos.email, datos.direccion, datos.telefono, datos.nCuenta, datos.nCedula, datos.personaCuenta);
        }
        public void eliminar(int id){
            db.spEliminarProveedor(id);
        }
        public Boolean modificar(mProveedores datos){
            Boolean result = false;
            try{
                db.spModificarProveedor(datos.id_proveedor, datos.persona_juridica, datos.RUC, datos.nombre, datos.descripcion, datos.email, datos.direccion, datos.telefono, datos.nCuenta, datos.nCedula, datos.personaCuenta);
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
                provee.Add(new mProveedores(item.id_proveedor, item.persona_juridica, item.RUC, item.nombre, item.descripcion, item.email, item.direccion, item.telefono, item.nCuenta, item.nCedula, item.personaCuenta));
            }
            return provee;
        }
        public mProveedores mostrarProveedor(int id){
            mProveedores objprov = new mProveedores();
            foreach (var item in db.spConsultarProveedorById(id))
            {
                objprov = new mProveedores(item.id_proveedor, item.persona_juridica, item.RUC, item.nombre, item.descripcion, item.email, item.direccion, item.telefono, item.nCuenta, item.nCedula, item.personaCuenta);
            }
            return objprov;
        }
        public mProveedores mostrarConvenio(int id){
            mProveedores objprov = new mProveedores();
            foreach (var item in db.spConsultarAsoProvbyID(id)){
                objprov = new mProveedores(item.id_proveedor, item.persona_juridica, item.RUC, item.nombre, item.descripcion, item.email, item.direccion, item.telefono, item.nCuenta, item.nCedula, item.personaCuenta, item.aso, Convert.ToDateTime(item.fecha), item.id_asoc_prov, Convert.ToInt32(item.asociacion_id), Convert.ToDouble(item.porcComision));
            }
            return objprov;
        }
        public List<mProveedores> mostrarxaso(int aso_id){
            foreach (var item in db.spConsultarProveedorxAso(aso_id)){
                provee.Add(new mProveedores(item.id_proveedor, item.persona_juridica, item.RUC, item.nombre, item.descripcion, item.email, item.direccion, item.telefono, item.nCuenta, item.nCedula, item.personaCuenta));
            }
            return provee;
        }
        
    }
}