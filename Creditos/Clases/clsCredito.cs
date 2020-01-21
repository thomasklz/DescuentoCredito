using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases { 
    public class clsCredito{
        Roles_Creditos_BDEntities db = new Roles_Creditos_BDEntities();
        public List<mCredito> mostrar(){
            List<mCredito> lista_creditos = new List<mCredito>();
            foreach (var item in db.spConsultarCredito()){
                lista_creditos.Add(new mCredito(item.id_credito, item.descripcion, Convert.ToDouble(item.cantidad), Convert.ToDateTime(item.fecha_solicitud), Convert.ToDateTime(item.fecha_aprobacion), Convert.ToDouble(item.desc_mensual), Convert.ToInt32(item.emp_aso_id), Convert.ToInt32(item.numero_cuota), Convert.ToBoolean(item.estado_activacion), Convert.ToBoolean(item.estado_aprobacion)));
            }
            return lista_creditos;
        }
        public void ingresar(mCredito datos){
            db.spInsertarCredito(datos.descripcion, datos.cantidad, datos.fecha_solicitud, datos.fecha_aprobacion, datos.desc_mensual, datos.emp_aso_id, datos.numero_cuota, datos.estado_activacion, datos.estado_aprobacion);
        }
        public void eliminar(mCredito datos){
            db.spEliminarCredito(datos.id_credito);
        }
        public void modificar(mCredito datos){
            db.spModificarCredito(datos.id_credito, datos.descripcion, datos.cantidad, datos.fecha_solicitud, datos.fecha_aprobacion, datos.desc_mensual, datos.emp_aso_id, datos.numero_cuota, datos.estado_activacion, datos.estado_aprobacion);
        }
    }
}