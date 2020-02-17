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

        //public JsonResult UpdateIngresos(mIngresos model)
        //{
        //    string result = "";
        //    try
        //    {
        //        if (clsingreso.modificar(model) == true)
        //        {
        //            result = "Registro actualizado";
        //        }
        //        else
        //        {
        //            result = "Error al actualizar";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        result = "Error al actualizar";
        //    }

        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}


        //public JsonResult GetIngresoById(int IngresoId)
        //{
        //    List<mIngresos> model = clsingreso.mostrarById(IngresoId);
        //    string value = string.Empty;
        //    value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //    });
        //    return Json(value, JsonRequestBehavior.AllowGet);
        //}


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
