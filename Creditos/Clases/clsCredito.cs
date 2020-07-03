using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Creditos.Models;
using Creditos.Entity;

namespace Creditos.Clases { 
    public class clsCredito{
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        List<mCredito> lista_creditos = new List<mCredito>();
        List<mCredito> lista_creditos1 = new List<mCredito>();
        mCredito objcred = new mCredito();
        public List<mCredito> mostrar(){
            foreach (var item in db.spConsultarCredito()){
                lista_creditos.Add(new mCredito(item.id_credito, item.descripcion, Convert.ToDouble(item.cantidad), Convert.ToDateTime(item.fecha_solicitud), Convert.ToDateTime(item.fecha_aprobacion), Convert.ToDouble(item.desc_mensual), item.persona, item.aso,Convert.ToInt32(item.emp_aso_id), Convert.ToInt32(item.numero_cuota), Convert.ToBoolean(item.estado_activacion), Convert.ToBoolean(item.estado_aprobacion), Convert.ToBoolean(item.estado_rechazo)));
            }
            return lista_creditos;
        }
        public List<mCredito> mostraract(){
            foreach (var item in db.spConsultarCreditosActivos())
            {
                lista_creditos.Add(new mCredito(item.id_credito, item.descripcion, Convert.ToDouble(item.cantidad), Convert.ToDateTime(item.fecha_solicitud), Convert.ToDateTime(item.fecha_aprobacion), Convert.ToDouble(item.desc_mensual), item.persona, item.aso, Convert.ToInt32(item.emp_aso_id), Convert.ToInt32(item.numero_cuota), Convert.ToBoolean(item.estado_activacion), Convert.ToBoolean(item.estado_aprobacion), Convert.ToBoolean(item.estado_rechazo)));
            }
            return lista_creditos;
        }
        public List<mCredito> mostrarRpt(int aso_id){
            foreach (var item in db.spReporteCredito(aso_id)){
                lista_creditos.Add(new mCredito(item.id_credito, item.persona, Convert.ToDouble(item.cantidad), Convert.ToDateTime(item.fecha_solicitud), Convert.ToDateTime(item.fecha_aprobacion), Convert.ToDouble(item.desc_mensual), Convert.ToInt32(item.numero_cuota), Convert.ToBoolean(item.estado_activacion), Convert.ToBoolean(item.estado_aprobacion), Convert.ToBoolean(item.estado_rechazo)));
            }
            return lista_creditos;
        }
        public void ingresar(mCredito datos){
            db.spInsertarCredito(datos.descripcion, datos.cantidad, datos.fecha_solicitud, datos.desc_mensual, datos.emp_aso_id, datos.numero_cuota);
        }
        public Boolean aprobar(int id){
            Boolean result = false;
            try{
                db.spAprobarCredito(id, Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                result = true;
            }catch (Exception){
                result = false;
            }
            return result;
        }
        public Boolean rechazar(int id)
        {
            Boolean result = false;
            try{
                db.spRechazarCredito(id,Convert.ToDateTime(DateTime.Now.ToShortDateString()));
                result = true;
            }catch (Exception){
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
                lista_creditos.Add(new mCredito(item.id_credito, item.descripcion, Convert.ToDouble(item.cantidad), Convert.ToDateTime(item.fecha_solicitud), Convert.ToDateTime(item.fecha_aprobacion), Convert.ToDouble(item.desc_mensual), item.persona, item.aso, item.id_empl_aso, Convert.ToInt32(item.numero_cuota), Convert.ToBoolean(item.estado_activacion), Convert.ToBoolean(item.estado_aprobacion), Convert.ToBoolean(item.estado_rechazo)));
            }
            return lista_creditos;
        }
        public mCredito mostrarobjCred(int id){
            foreach (var item in db.spConsultarCreditoById(id)){
                objcred= new mCredito(item.id_credito, item.descripcion, Convert.ToDouble(item.cantidad), Convert.ToDateTime(item.fecha_solicitud), Convert.ToDateTime(item.fecha_aprobacion), Convert.ToDouble(item.desc_mensual), item.persona, item.Cedula, item.aso, item.id_empl_aso, Convert.ToInt32(item.numero_cuota), Convert.ToBoolean(item.estado_activacion), Convert.ToBoolean(item.estado_aprobacion), Convert.ToBoolean(item.estado_rechazo));
            }
            return objcred;
        }
        public List<mCredito> mostrarByUser(int id){
            foreach (var item in db.spConsultarCreditosEmpleado(id)){
                lista_creditos.Add(new mCredito(item.id_credito, item.descripcion, Convert.ToDouble(item.cantidad), Convert.ToDateTime(item.fecha_solicitud), Convert.ToDateTime(item.fecha_aprobacion), Convert.ToDouble(item.desc_mensual), item.persona, item.Cedula, item.aso, item.id_empl_aso, Convert.ToInt32(item.numero_cuota), Convert.ToBoolean(item.estado_activacion), Convert.ToBoolean(item.estado_aprobacion), Convert.ToBoolean(item.estado_rechazo)));
            }
            return lista_creditos;
        }
        public List<mCredito> mostrarNoAp(){
            foreach (var item in db.spConsultarCreditosNoAprobados()){
                lista_creditos1.Add(new mCredito(item.id_credito, item.descripcion, Convert.ToDouble(item.cantidad), Convert.ToDateTime(item.fecha_solicitud), Convert.ToDateTime(item.fecha_aprobacion), Convert.ToDouble(item.desc_mensual), item.persona, item.aso, item.id_empl_aso, Convert.ToInt32(item.numero_cuota), Convert.ToBoolean(item.estado_activacion), Convert.ToBoolean(item.estado_aprobacion), Convert.ToBoolean(item.estado_rechazo)));
            }
            return lista_creditos1;
        }
    }
}