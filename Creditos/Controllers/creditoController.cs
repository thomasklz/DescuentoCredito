using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Creditos.Clases;
using Creditos.Models;
using Creditos.Entity;
using Newtonsoft.Json;

namespace Creditos.Controllers{
    public class creditoController : Controller
    {
        // GET: credito
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsAsociacion clsaso = new clsAsociacion();
        clsEmpleadoAsociacion clsempl_aso = new clsEmpleadoAsociacion();
        clsCredito clscred = new clsCredito();
        List<mCredito> list_credito = new List<mCredito>();

        public ActionResult indexU(){
            ViewBag.credxus = clscred.mostrarByUser(3);
            return View();
        }
        public ActionResult indexA()
        {
            ViewBag.credNoAp = clscred.mostrarNoAp();
            ViewBag.creditos = clscred.mostrar();
            return View();
        }
        public ActionResult Store(mCredito model){
            clscred.ingresar(model);
            return RedirectToAction("indexU");
        }
        public JsonResult UpdateCredito(mCredito model){
            string result = "";
            try{
                if (clscred.modificar(model) == true){
                    result = "Registro actualizado";
                }else{
                    result = "Error al actualizar";
                }
            }catch (Exception){
                result = "Error al actualizar";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteCredito(int CreditoId){
            string result = "";
            Credito cred = db.Credito.Find(CreditoId);
            if (cred != null){
                clscred.eliminar(CreditoId);
                result = "Eliminado";
            }else{
                result = "Registro no encontrado";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult AprobarCredito(int CreditoId){
            string result = "";
            try{
                if (clscred.aprobar(CreditoId) == true){
                    result = "Credito aprobado";
                }else{
                    result = "Error";
                }
            }catch (Exception){
                result = "Error";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCreditoById(int CreditoId)
        {
            List<mCredito> model = clscred.mostrarById(CreditoId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ValidarCredito(string _descr, string _cantidad, string _nCuotas, string _descMensual,string _fecha, string _idEmplAso)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                if (string.IsNullOrEmpty(_descr) || string.IsNullOrEmpty(_cantidad) || string.IsNullOrEmpty(_nCuotas) || string.IsNullOrEmpty(_descMensual) || string.IsNullOrEmpty(_fecha) || string.IsNullOrEmpty(_idEmplAso))
                {
                    _mensaje = "<div class='alert alert-danger text-center' role='alert'>Ingrese todos los datos</div>";
                }
                else
                {
                    _mensaje = "";
                    _validar = true;
                    return Json(new { mensaje = _mensaje, validar = _validar }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                _mensaje = "<div class='alert alert-danger text-center' role='alert'>ERROR INTERNO DEL SISTEMA: " + ex.Message + "</div>";
            }
            return Json(new { mensaje = _mensaje, validar = _validar }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RechazarCredito(int CreditoId){
            string result = "";
            try{
                if (clscred.rechazar(CreditoId) == true){
                    result = "Credito rechazado";
                }else{
                    result = "Error";
                }
            }catch (Exception){
                result = "Error";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ConsultarCreditoR(string _idAso)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                int _idAsoEnt = Convert.ToInt32(_idAso);
                list_credito = clscred.mostrarRpt(_idAsoEnt);
                var _objAso = clsaso.mostrar().Where(c => c.id_asociacion == _idAsoEnt).FirstOrDefault();
                var nuevafila = "";
                for (int i = 0; i < list_credito.Count; i++)
                {
                    var idNV = list_credito[i].id_credito;
                    nuevafila += "<tr class='rows_" + idNV + "'><td colspan='1'><center>" +
                        (i + 1) + "</center></td><td colspan='2'>● " +
                        list_credito[i].persona + "</td><td colspan='1'><center> " +
                        list_credito[i].cantidad + "</center></td><td colspan='1'><center>" +
                        list_credito[i].numero_cuota + " meses</center></td><td colspan='1'><center>" +
                        list_credito[i].desc_mensual + "</center></td>";
                        if(list_credito[i].estado_rechazo == false && list_credito[i].estado_aprobacion == false){
                        nuevafila += "<td>No se ha revisado</td>";
                                }else if ((list_credito[i].estado_aprobacion == true || list_credito[i].estado_rechazo == true) && list_credito[i].estado_activacion == false){
                            nuevafila += "<td>INACTIVO</td>";
                                    }else { nuevafila += "<td>ACTIVO</td>"; }
                    nuevafila += "<td colspan='1'><center>" +
                    list_credito[i].fecha_solicitud.ToShortDateString() + "</center></td><td colspan='1'><center>";
                    if(list_credito[i].estado_rechazo == false && list_credito[i].estado_aprobacion == false && list_credito[i].estado_activacion == false){
                        nuevafila += "No se ha revisado</center></td></tr>";
                    }
                    else {nuevafila += list_credito[i].fecha_aprobacion.ToShortDateString() + "</center></td></tr>";
 }
                }

                string tbody = "<tbody>" + nuevafila + "</tbody>";

                string _tablaFinal = "<table class='table' width='80%' border='1'cellspacing='0' cellpadding='0' style='margin: 0 auto;'>" +
             "<thead>" +
                "<tr>" +
                 "<th colspan='9'><center><img src='../Content/media/logos/espam.jpg' width='50%' height='70%'></center></th> " +
                "</tr> " +
                "<tr>" +
                  "<th colspan='9'><h2><center>LISTADO DE CRÉDITOS - AÑO " + DateTime.Now.Year + "<br/></center></h2></th>" +
                "</tr> " +
                "<tr>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>FECHA:<br/></b></center></th>" +
                  "<td colspan='2'><center><br/>" + DateTime.Now.ToShortDateString() + "<br/></center></td>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>AÑO:<br/></b></center></th>" +
                  "<td colspan='1'><center><br/>" + DateTime.Now.Year + "<br/></center></td>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><center><b><br/>ASOCIACIÓN:<br/></b></center></th>" +
                  "<td colspan='2'><center><br/>" + _objAso.descripcion.ToUpper() + "<br/></center></td>" +
                 "</tr>" +
                "<tr>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/> Item <br/></b></center></th>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><b><br/>◢ EMPLEADO ◣<br/></b></th>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>CANTIDAD<br/></b></center></th>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>PLAZO<br/></b></center></th>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>Desc./Mes<br/></b></center></th>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>ESTADO<br/></b></center></th>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>F. SOLICITUD<br/></b></center></th>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>F. REVISIÓN<br/></b></center></th>" +
                "</tr>" +
              "</thead>" +
              tbody +
                "</table>";

                _mensaje = "";
                _validar = true;
                return Json(new { mensaje = _mensaje, validar = _validar, tabla = _tablaFinal }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _mensaje = "<div class='alert alert-danger text-center' role='alert'>ERROR INTERNO DEL SISTEMA: " + ex.Message + "</div>";
            }
            return Json(new { mensaje = _mensaje, validar = _validar }, JsonRequestBehavior.AllowGet);


        }
        public ActionResult ConsultarReciboCreditoR(string _idCredito, string _idAso)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                int _idCredEntero = Convert.ToInt32(_idCredito);
                var _objCredito = clscred.mostrarobjCred(_idCredEntero);
                Moneda oMoneda = new Moneda();
                int _idAsoEntero = Convert.ToInt32(_idAso);
                var _objAso = clsaso.mostrar().Where(c => c.id_asociacion == _idAsoEntero).FirstOrDefault();
                string aso = ""; string prs = ""; string tsrr = "";
                if (_objAso.descripcion == "AETPAM") {
                    aso += "ASOCIACIÓN DE EMPLEADOS Y TRABAJADORES DE LA ESCUELA SUPERIOR POLITÉCNICA AGROPECURIA DE MANABÍ “MANUEL FÉLIX LÓPEZ”";
                    prs += "Ing. Fabián Álava Rade";
                    tsrr += "Lcda. Talia Saavedra Escalante";
                }
                else{
                    aso += "ASOCIACIÓN DE PROFESORES DE LA ESCUELA SUPERIOR POLITÉCNICA AGROPECURIA DE MANABÍ “MANUEL FÉLIX LÓPEZ”";
                    prs += "Ing. Gabriel Navarrete";
                    tsrr += "Lcda. Maricela Gonzales";
                }

                string resultado = oMoneda.Convertir((_objCredito.cantidad).ToString(), true, "DOLARES");

                string _tablaFinal = "<table class='table' width='80%' cellspacing='0' cellpadding='0' style='margin: 0 auto;'>" +
             "<thead>" +
                "<tr>" +
                  "<td colspan='5' style='text-align:right;'><h4><b><br/><br/><br/><br/> N°: ______. </b></h4></td><br/>" +
                "</tr> " +
                "<tr>" +
                  "<th colspan='5'><h2><center><br/>RECIBO<br/></center></h2></th>" +
                "</tr> " +
                "<tr>" +
                  "<td colspan='1'></td>" +
                  "<td colspan='3' style='text-align: justify;'><br/><br/><h4> Yo, <b>" + _objCredito.persona + "</b>," +
                  "  con cédula de ciudadanía Nº: <b>" + _objCredito.cedula + "</b> recibí " +
                  "de la " + aso + " la Cantidad de <b> $ " + _objCredito.cantidad + "</b> (" + resultado + " de" +
                  " los Estados Unidos de Norte América), en calidad de PRÉSTAMO, mismos que me comprometo a " +
                  "cancelar por medio de <b> DESCUENTOS POR ROL,</b> en " + _objCredito.numero_cuota + " cuotas de <b>$ " + _objCredito.desc_mensual +
                  "</b> dólares  a partir del mes de <b>______/" + DateTime.Now.Year + "</b>.</h4></td>" +
                  "<td colspan='1'></td>" +
                 "</tr>" +
                 "<tr>" +
                   "<th colspan='10'></th>" +
                "</tr> " +
                "<tr>" +
                   "<th colspan='10'><h4>Calceta, " + DateTime.Now.ToString("MMMM dd, yyyy") + "</h4></th>" +
                "</tr> " +
                "<tr>" +
                   "<th colspan='10'><br/><br/><br/></th>" +
                "</tr> " +
                "<tr>" +
                  "<td colspan='1'></td>" +
                  "<td colspan='1' style='background-color:#f7f5f5'><center><b> ________________<br/></b></center></th>" +
                  "<td colspan='1' style='background-color:#f7f5f5'><center><b> ________________<br/></b></center></th>" +
                  "<td colspan='1' style='background-color:#f7f5f5'><center><b> ________________<br/></b></center></th>" +
                  "<td colspan='1'></td>" +
                "</tr>" +
                "<tr>" +
                  "<td colspan='1'></td>" +
                  "<td colspan='1' style='background-color:#f7f5f5'><center><b> RECIBÍ CONFORME <br/></b></center></th>" +
                  "<td colspan='1' style='background-color:#f7f5f5'><center><b> ENTREGUÉ CONFORME<br/></b></center></th>" +
                  "<td colspan='1' style='background-color:#f7f5f5'><center><b> ENTREGUÉ CONFORME<br/></b></center></th>" +
                  "<td colspan='1'></td>" +
                "</tr>" +
                "<tr>" +
                  "<td colspan='1'></td>" +
                  "<td colspan='1'><center>"+_objCredito.persona+"</center></th>" +
                  "<td colspan='1'><center>"+prs+"</center></th>" +
                  "<td colspan='1'><center>"+tsrr+"</center></th>" +
                  "<td colspan='1'></td>" +
                "</tr>" +
                "<tr>" +
                  "<td colspan='1'></td>" +
                  "<td colspan='1'><center><b> C.C.:" + _objCredito.cedula + " </b></center></th>" +
                  "<td colspan='1'><center><b> PRESIDENTE - "+_objAso.descripcion+"</b></center></th>" +
                  "<td colspan='1'><center><b> TESORERA - " + _objAso.descripcion + "</b></center></th>" +
                  "<td colspan='1'></td>" +
                "</tr>" +
              "</thead>" +
              "</table>";

                _mensaje = "";
                _validar = true;
                return Json(new { mensaje = _mensaje, validar = _validar, tabla = _tablaFinal }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _mensaje = "<div class='alert alert-danger text-center' role='alert'>ERROR INTERNO DEL SISTEMA: " + ex.Message + "</div>";
            }
            return Json(new { mensaje = _mensaje, validar = _validar }, JsonRequestBehavior.AllowGet);

        }
    }
}
