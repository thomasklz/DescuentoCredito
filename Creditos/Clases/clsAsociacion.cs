using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsAsociacion {
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        public List<mAsociacion> mostrar(){
            List<mAsociacion> lista_asociacion = new List<mAsociacion>();
            foreach (var item in db.spConsultarAsociacion()){
                lista_asociacion.Add(new mAsociacion(item.id_asociacion, item.descripcion));
            }
            return lista_asociacion;
        }
        public void ingresar(mAsociacion datos){
            db.spInsertarAsociacion(datos.descripcion);
        }
        public void eliminar(mAsociacion datos){
            db.spEliminarAsociacion(datos.id_asociacion);
        }
        public void modificar(mAsociacion datos){
            db.spModificarAsociacion(datos.id_asociacion, datos.descripcion);
        }
    }
}