using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsIngresos{
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        List<mIngresos> ingr = new List<mIngresos>();
        public List<mIngresos> mostrar(){
            foreach (var item in db.spConsultarIngreso()){
                ingr.Add(new mIngresos(item.id_ingresos, item.valor, item.tipoingreso, item.mes));
            }
            return ingr;
        }
        public void ingresar(mIngresos datos){
            db.spInsertarIngreso(datos.valor, datos.asociacion_id, datos.tipo_ingreso_id, datos.mes_id);
        }
        public void eliminar(int id){
            db.spEliminarIngreso(id);
        }
        public Boolean modificar(mIngresos datos){
            Boolean result = false;
            try
            {
                db.spModificarIngreso(datos.id_ingresos, datos.valor, datos.asociacion_id, datos.tipo_ingreso_id, datos.mes_id);
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
        public List<mIngresos> mostrarById(int id){
            foreach (var item in db.spConsultarIngresoById(id))
            {
                ingr.Add(new mIngresos(item.id_ingresos, item.valor, item.id_tipo_ingreso, item.id_mes));
            }
            return ingr;
        }
    }
}