using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases{
    public class clsIngresos{
        Entities db = new Entities();
        public List<mIngresos> mostrar(){
            List<mIngresos> lista_ingresos = new List<mIngresos>();
            foreach (var item in db.spConsultarIngreso()){
                lista_ingresos.Add(new mIngresos(item.id_ingresos, item.valor, Convert.ToInt32(item.asociacion_id), Convert.ToInt32(item.tipo_ingreso_id), Convert.ToInt32(item.mes_id)));
            }
            return lista_ingresos;
        }
        public void ingresar(mIngresos datos){
            db.spInsertarIngreso(datos.valor, datos.asociacion_id, datos.tipo_egreso_id, datos.mes_id);
        }
        public void eliminar(mIngresos datos){
            db.spEliminarIngreso(datos.id_ingresos);
        }
        public void modificar(mIngresos datos){
            db.spModificarIngreso(datos.id_ingresos, datos.valor, datos.asociacion_id, datos.tipo_egreso_id, datos.mes_id);
        }
    }
}