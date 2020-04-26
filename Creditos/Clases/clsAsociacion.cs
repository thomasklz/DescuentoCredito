using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsAsociacion {
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        List<mAsociacion> aso = new List<mAsociacion>();
        public List<mAsociacion> mostrar(){
            foreach (var item in db.spConsultarAsociacion()){
                aso.Add(new mAsociacion(item.id_asociacion, item.descripcion));
            }
            return aso;
        }
        public void ingresar(mAsociacion datos){
            db.spInsertarAsociacion(datos.descripcion);
        }
        public void eliminar(int id){
            db.spEliminarAsociacion(id);
        }
        public Boolean modificar(mAsociacion datos){
            Boolean result = false;
            try{
                db.spModificarAsociacion(datos.id_asociacion, datos.descripcion);
                result = true;
            }catch (Exception){
                result = false;
            }
            return result;
        }
        public List<mAsociacion> mostrarById(int id){
            foreach (var item in db.spConsultarAsociacionById(id)){
                aso.Add(new mAsociacion(item.id_asociacion, item.descripcion));
            }
            return aso;
        }
    }
}