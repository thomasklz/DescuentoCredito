using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsEmpleadoAsociacion{
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        List<mEmpleadoAsociacion> lista_empl_Aso = new List<mEmpleadoAsociacion>();
        public List<mEmpleadoAsociacion> mostrar(){
            foreach (var item in db.spConsultarEmpleadoAsociacion())
            {
                lista_empl_Aso.Add(new mEmpleadoAsociacion(item.id_empl_aso, item.persona, item.Id_Persona, item.aso, Convert.ToDateTime(item.fecha_ingreso)));
            }
            return lista_empl_Aso;
        }
        public void ingresar(mEmpleadoAsociacion datos){
            db.spInsertarEmpleadoAsociacion(datos.empleado_id, datos.asociacion_id, datos.fecha_ingreso);

        }
        public void eliminar(int id){
            db.spEliminarEmpleadoAsociacion(id);
        }
        public Boolean modificar(mEmpleadoAsociacion datos){
            Boolean result = false;
            try{
                db.spModificarEmpleadoAsociacion(datos.id_empl_aso, datos.empleado_id, datos.asociacion_id, datos.fecha_ingreso);
                result = true;
            }
            catch (Exception){
                result = false;
            }
            return result;
        }
        public List<mEmpleadoAsociacion> mostrarById(int id){
            foreach (var item in db.spConsultarEmpleadoAsociacionById(id)){
                lista_empl_Aso.Add(new mEmpleadoAsociacion(item.id_empl_aso, item.Id_Persona, item.id_asociacion, Convert.ToDateTime(item.fecha_ingreso)));
            }
            return lista_empl_Aso;
        }
    }
}