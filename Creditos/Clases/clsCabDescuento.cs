using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsCabDescuento{
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        List<mCabDescuento> cab_desc = new List<mCabDescuento>();
        public List<mCabDescuento> mostrar(){
            foreach (var item in db.spConsultarCabeceraDescuento()){
                cab_desc.Add(new mCabDescuento(item.id_cabecera_descuento, item.descripcion, item.subdescuento));
            }
            return cab_desc;
        }
        public void ingresar(mCabDescuento datos){
            db.spInsertarCabeceraDescuento(datos.descripcion, datos.subdescuento_id);
        }
        public void eliminar(int id){
            db.spEliminarCabeceraDescuento(id);
        }
        public Boolean modificar(mCabDescuento datos){
            Boolean result = false;
            try{
                db.spModificarCabeceraDescuento(datos.id_cabecera_descuento, datos.descripcion, datos.subdescuento_id);
                result = true;
            }catch (Exception){
                result = false;
            }
            return result;
        }
        public List<mCabDescuento> mostrarById(int id){
            foreach (var item in db.spConsultarCabeceraDescuentoById(id)){
                cab_desc.Add(new mCabDescuento(item.id_cabecera_descuento, item.descripcion, item.subdescuento));
            }
            return cab_desc;
        }
    }
}