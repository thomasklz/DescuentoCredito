using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases { 
    public class clsCredito{
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        List<mCredito> lista_creditos = new List<mCredito>();
        List<mCredito> lista_creditos1 = new List<mCredito>();
        public List<mCredito> mostrar()
        {
            foreach (var item in db.spConsultarCredito())
            {
                lista_creditos.Add(new mCredito(item.id_credito, item.descripcion, Convert.ToDouble(item.cantidad), Convert.ToDateTime(item.fecha_solicitud), Convert.ToDateTime(item.fecha_aprobacion), Convert.ToDouble(item.desc_mensual), item.persona, item.aso, Convert.ToInt32(item.numero_cuota), Convert.ToBoolean(item.estado_activacion), Convert.ToBoolean(item.estado_aprobacion)));
            }
            return lista_creditos;
        }
        public void ingresar(mCredito datos){
            db.spInsertarCredito(datos.descripcion, datos.cantidad, datos.fecha_solicitud, datos.desc_mensual, datos.emp_aso_id, datos.numero_cuota);
        }
        public Boolean aprobar(mCredito datos){
            Boolean result = false;
            try{
                db.spAprobarCredito(datos.id_credito, datos.fecha_aprobacion);
                result = true;
            }
            catch (Exception){
                result = false;
            }
            return result;
        }
        public void eliminar(int id){
            db.spEliminarCredito(id);
        }
        public Boolean modificar(mCredito datos){
            Boolean result = false;
            try{
                db.spModificarCredito(datos.id_credito, datos.descripcion, datos.cantidad, datos.fecha_solicitud, datos.fecha_aprobacion, datos.desc_mensual, datos.emp_aso_id, datos.numero_cuota, datos.estado_activacion, datos.estado_aprobacion);
                result = true;
            }
            catch (Exception){
                result = false;
            }
            return result;
        }

        public List<mCredito> mostrarById(int id){
            foreach (var item in db.spConsultarCreditoById(id)){
                lista_creditos.Add(new mCredito(item.id_credito, item.descripcion, Convert.ToDouble(item.cantidad), Convert.ToDateTime(item.fecha_solicitud), Convert.ToDateTime(item.fecha_aprobacion), Convert.ToDouble(item.desc_mensual), item.persona, item.aso, Convert.ToInt32(item.numero_cuota), Convert.ToBoolean(item.estado_activacion), Convert.ToBoolean(item.estado_aprobacion)));
            }
            return lista_creditos;
        }
        public List<mCredito> mostrarByUser(int id){
            foreach (var item in db.spConsultarCreditosEmpleado(id)){
                lista_creditos.Add(new mCredito(item.id_credito, item.descripcion, Convert.ToDouble(item.cantidad), Convert.ToDateTime(item.fecha_solicitud), Convert.ToDateTime(item.fecha_aprobacion), Convert.ToDouble(item.desc_mensual), item.persona, item.aso, Convert.ToInt32(item.numero_cuota), Convert.ToBoolean(item.estado_activacion), Convert.ToBoolean(item.estado_aprobacion)));
            }
            return lista_creditos;
        }
        public List<mCredito> mostrarNoAp(){
            foreach (var item in db.spConsultarCreditosNoAprobados()){
                lista_creditos1.Add(new mCredito(item.id_credito, item.descripcion, Convert.ToDouble(item.cantidad), Convert.ToDateTime(item.fecha_solicitud), Convert.ToDateTime(item.fecha_aprobacion), Convert.ToDouble(item.desc_mensual), item.persona, item.aso, Convert.ToInt32(item.numero_cuota), Convert.ToBoolean(item.estado_activacion), Convert.ToBoolean(item.estado_aprobacion)));
            }
            return lista_creditos1;
        }
    }
}