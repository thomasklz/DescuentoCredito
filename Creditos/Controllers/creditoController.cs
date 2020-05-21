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
        clsEmpleadoAsociacion clsempl_aso = new clsEmpleadoAsociacion();
        //clsIngresos clsingreso = new clsIngresos();
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
        public ActionResult ConsultarCreditoR(){
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                list_credito = clscred.mostrarRpt(1);
                var nuevafila = "";
                for (int i = 0; i < list_credito.Count; i++)
                {
                    var idNV = list_credito[i].id_credito;
                    nuevafila += "<tr class='rows_" + idNV + "'><td colspan='1'><center>" +
                        (i + 1) + "</center></td><td colspan='2'>● " +
                        list_credito[i].persona + "</td><td colspan='1'><center> " +
                        list_credito[i].cantidad + "</center></td><td colspan='1'><center>" +
                        list_credito[i].numero_cuota + "</center></td><td colspan='1'><center>" +
                        list_credito[i].desc_mensual + "</center></td><td colspan='1'><center>" +
                        list_credito[i].estado_activacion + "</center></td><td colspan='1'><center>" +
                        list_credito[i].fecha_solicitud.ToShortDateString() + "</center></td><td colspan='1'><center>" +
                        list_credito[i].fecha_aprobacion.ToShortDateString() + "</center></td></tr>";
                }

                string tbody = "<tbody>" + nuevafila + "</tbody>";

                string _tablaFinal = "<table class='table' width='80%' border='1'cellspacing='0' cellpadding='0' style='margin: 0 auto;'>" +
             "<thead>" +
                "<tr>" +
                 "<th colspan='9'><center><img src='../Content/media/logos/espam.png' width='80%' height='120%'></center></th> " +
                "</tr> " +
                "<tr>" +
                  "<th colspan='9'><h2><center><br/>LISTADO DE PROVEEDORES ASOCIADOS<br/></center></h2></th>" +
                "</tr> " +
                "<tr>" +
                  "<th colspan='3' style='background-color:#f7f5f5'><center><b><br/>Fecha Actual<br/></b></center></th>" +
                  "<td colspan='2'><center><br/>" + DateTime.Now.ToShortDateString() + "<br/></center></td>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><center><b><br/>ASOCIACIÓN<br/></b></center></th>" +
                  "<td colspan='2'><center><br/>AETPAM<br/></center></td>" +
                 "</tr>" +
                "<tr>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/> Item <br/></b></center></th>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><b><br/>◢ EMPLEADO ◣<br/></b></th>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>CANTIDAD<br/></b></center></th>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>PLAZO<br/></b></center></th>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>Desc/Mens<br/></b></center></th>" +
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
    }
}
