using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsEmpleadoAsociacion{
        Roles_Creditos_BDEntities db = new Roles_Creditos_BDEntities();
        public List<mEmpleadoAsociacion> mostrar(){
            List<mEmpleadoAsociacion> lista_empl_aso = new List<mEmpleadoAsociacion>();
            foreach (var item in db.spConsultarEmpleadoAsociacion()){
       //         lista_empl_aso.Add(new mEmpleadoAsociacion(item.id_empl_aso, Convert.ToInt32(item.empleado_id), Convert.ToInt32(item.asociacion_id), Convert.ToDateTime(item.fecha_ingreso)));
            }
            return lista_empl_aso;
        }
        public void ingresar(mEmpleadoAsociacion datos){
            db.spInsertarEmpleadoAsociacion(datos.empleado_id, datos.asociacion_id, datos.fecha_ingreso);
        }
        public void eliminar(mEmpleadoAsociacion datos){
            db.spEliminarEmpleadoAsociacion(datos.id_empl_aso);
        }
        public void modificar(mEmpleadoAsociacion datos){
       //     db.spModificarEmpleadoAsociacion(datos.id_empl_aso, datos.empleado_id, datos.asociacion_id, datos.fecha_ingreso);
        }
    }
}