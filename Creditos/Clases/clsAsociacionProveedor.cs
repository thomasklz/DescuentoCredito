using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsAsociacionProveedor{
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        List<mAsociacionProveedor> lista_Aso_rpov = new List<mAsociacionProveedor>();
        public List<mAsociacionProveedor> mostrar(){
            foreach (var item in db.spConsultarAsociacionProveedor()){
                lista_Aso_rpov.Add(new mAsociacionProveedor(item.id_asoc_prov, item.proveedor, item.id_proveedor, item.aso, Convert.ToDateTime(item.fecha),Convert.ToDouble(item.porcComision)));
            }
            return lista_Aso_rpov;
        }
        public List<mAsociacionProveedor> mostrarRpt(int aso_id){
            foreach (var item in db.spReporteAsoProv(aso_id))
            {
                lista_Aso_rpov.Add(new mAsociacionProveedor(item.id_asoc_prov, item.proveedor, Convert.ToDateTime(item.fecha)));
            }
            return lista_Aso_rpov;
        }
        public List<mAsociacionProveedor> mostrarInPg(int aso_id){
            foreach (var item in db.spReporteInfoProvdrs(aso_id)){
                lista_Aso_rpov.Add(new mAsociacionProveedor(item.id_asoc_prov, item.proveedor, item.institucion_bncria, item.tipo_cuenta_bncria, item.nCedula, item.personaCuenta, item.nCuenta, Convert.ToDouble(item.valor_a_pagar)));
            }
            return lista_Aso_rpov;
        }
        public void ingresar(mAsociacionProveedor datos){
            db.spInsertarAsociacionProveedor(datos.proveedor_id, datos.asociacion_id, datos.fecha, datos.porcCom);

        }
        public void eliminar(int id){
            db.spEliminarAsociacionProveedor(id);
        }
        public Boolean modificar(mAsociacionProveedor datos){
            Boolean result = false;
            try{
                db.spModificarAsociacionProveedor(datos.id_asoc_prov, datos.proveedor_id, datos.asociacion_id, datos.fecha, datos.porcCom);
                result = true;
            }
            catch (Exception){
                result = false;
            }
            return result;
        }
        public List<mAsociacionProveedor> mostrarById(int id){
            foreach (var item in db.spConsultarAsociacionProveedorById(id)){
                lista_Aso_rpov.Add(new mAsociacionProveedor(item.id_asoc_prov, item.id_proveedor, item.proveedor, item.id_asociacion, Convert.ToDateTime(item.fecha), Convert.ToDouble(item.porcComision)));
            }
            return lista_Aso_rpov;
        }
    }
}