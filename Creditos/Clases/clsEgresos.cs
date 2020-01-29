using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsEgresos{
        AdministracionAcademicaEntities db = new AdministracionAcademicaEntities();
        public List<mEgresos> mostrar(){
            List<mEgresos> lista_egresos = new List<mEgresos>();
            foreach (var item in db.spConsultarEgreso()){
                lista_egresos.Add(new mEgresos(item.id_egresos, Convert.ToDouble(item.valor), Convert.ToInt32(item.asociacion_id), Convert.ToInt32(item.tipo_egreso_id), Convert.ToInt32(item.mes_id)));
            }
            return lista_egresos;
        }
        public void ingresar(mEgresos datos){
            db.spInsertarEgreso(datos.valor, datos.asociacion_id, datos.tipo_egreso_id, datos.mes_id);
        }
        public void eliminar(mEgresos datos){
            db.spEliminarEgreso(datos.id_egresos);
        }
        public void modificar(mEgresos datos){
            db.spModificarEgreso(datos.id_egresos, datos.valor, datos.asociacion_id, datos.tipo_egreso_id, datos.mes_id);
        }
    }
}