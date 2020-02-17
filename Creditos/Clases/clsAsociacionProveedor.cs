using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsAsociacionProveedor{
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        List<mAsociacionProveedor> lista_Aso_rpov = new List<mAsociacionProveedor>();
        public List<mAsociacionProveedor> mostrar(){
            foreach (var item in db.spConsultarAsociacionProveedor()){
                lista_Aso_rpov.Add(new mAsociacionProveedor(item.id_asoc_prov, item.proveedor, item.aso, Convert.ToDateTime(item.fecha)));
            }
            return lista_Aso_rpov;
        }
        public void ingresar(mAsociacionProveedor datos){
            db.spInsertarAsociacionProveedor(datos.proveedor_id, datos.asociacion_id, datos.fecha);

        }
        public void eliminar(int id){
            db.spEliminarAsociacionProveedor(id);
        }
        public Boolean modificar(mAsociacionProveedor datos){
            Boolean result = false;
            try{
                db.spModificarAsociacionProveedor(datos.id_asoc_prov, datos.proveedor_id, datos.asociacion_id, datos.fecha);
                result = true;
            }
            catch (Exception){
                result = false;
            }
            return result;
        }
        public List<mAsociacionProveedor> mostrarById(int id){
            foreach (var item in db.spConsultarAsociacionProveedorById(id)){
                lista_Aso_rpov.Add(new mAsociacionProveedor(item.id_asoc_prov, item.proveedor, item.aso, Convert.ToDateTime(item.fecha)));
            }
            return lista_Aso_rpov;
        }
    }
}