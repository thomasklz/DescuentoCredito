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
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
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

        public JsonResult AprobarCredito(mCredito model){
            string result = "";
            try{
                if (clscred.aprobar(model) == true){
                    result = "Credito Aprobado";
                }else{
                    result = "Error al Aprobar";
                }
            }catch (Exception){
                result = "Error al Aprobar";
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

        //public JsonResult DeleteIngreso(int IngresoId)
        //{
        //    string result = "";
        //    Ingresos ingreso = db.Ingresos.Find(IngresoId);
        //    if (ingreso != null)
        //    {
        //        clsingreso.eliminar(IngresoId);
        //        result = "Eliminado";
        //    }
        //    else
        //    {
        //        result = "Registro no encontrado";
        //    }

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}
