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
                lista_ingresos.Add(new mIngresos(item.id_ingresos, item.valor, item.asociacion_id, item.tipo_ingreso_id, item.mes_id));
            }
            return lista_ingresos;
        }
        public void ingresar(mIngresos datos){
            db.spInsertarCabeceraDescuento(datos.descripcion, datos.subdescuento_id);
        }
        public void eliminar(mIngresos datos){
            db.spEliminarCabeceraDescuento(datos.id_cabecera_descuento);
        }
        public void modificar(mIngresos datos){
            db.spModificarCabeceraDescuento(datos.id_cabecera_descuento, datos.descripcion, datos.subdescuento_id);
        }
    }
}