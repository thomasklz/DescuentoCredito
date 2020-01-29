using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsAsociacionProveedor{
        AdministracionAcademicaEntities db = new AdministracionAcademicaEntities();
        public List<mAsociacionProveedor> mostrar(){
            List<mAsociacionProveedor> lista_aso_prov = new List<mAsociacionProveedor>();
            foreach (var item in db.spConsultarAsociacionProveedor()){
                lista_aso_prov.Add(new mAsociacionProveedor(item.id_asoc_prov, Convert.ToInt32(item.proveedor_id),Convert.ToInt32(item.asociacion_id),Convert.ToDateTime(item.fecha)));
            }
            return lista_aso_prov;
        }
        public void ingresar(mAsociacionProveedor datos){
            db.spInsertarAsociacionProveedor(datos.proveedor_id, datos.asociacion_id, datos.fecha);
        }
        public void eliminar(mAsociacionProveedor datos){
            db.spEliminarAsociacionProveedor(datos.id_asoc_prov);
        }
        public void modificar(mAsociacionProveedor datos){
            db.spModificarAsociacionProveedor(datos.id_asoc_prov, datos.proveedor_id, datos.asociacion_id, datos.fecha);
        }
    }
}