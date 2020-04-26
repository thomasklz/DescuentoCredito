using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsEgresos{
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        List<mEgresos> egr = new List<mEgresos>();

        public List<mEgresos> mostrar(){
            foreach (var item in db.spConsultarEgreso())
            {
                egr.Add(new mEgresos(item.id_egresos, Convert.ToDouble(item.valor), item.tipoegreso, item.mes));
            }
            return egr;
        }
        public void ingresar(mEgresos datos){
            db.spInsertarEgreso(datos.valor, datos.asociacion_id, datos.tipo_egreso_id, datos.mes_id);
        }
        public void eliminar(int id){
            db.spEliminarEgreso(id);
        }
        public Boolean modificar(mEgresos datos){
            Boolean result = false;
            try{
                db.spModificarEgreso(datos.id_egresos, datos.valor, datos.asociacion_id, datos.tipo_egreso_id, datos.mes_id);
                result = true;
            }catch (Exception){
                result = false;
            }
            return result;
        }
        public List<mEgresos> mostrarById(int id){
            foreach (var item in db.spConsultarEgresoById(id)){
                egr.Add(new mEgresos(item.id_egresos, Convert.ToDouble(item.valor), item.id_tipo_egreso, item.id_mes));
            }
            return egr;
        }
    }
}