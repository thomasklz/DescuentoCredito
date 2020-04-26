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
    }
}
