using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Creditos.Clases;
using Creditos.Models;
using Creditos.Entity;
using Newtonsoft.Json;


namespace Creditos.Controllers
{
    public class asociacionController : Controller
    {
        // GET: asociacion
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        clsAsociacion asoc = new clsAsociacion();
        List<mAsociacion> list_aso = new List<mAsociacion>();
        public ActionResult Index()
        {
            ViewBag.asoc = asoc.mostrar();
            return View();
        }

        public ActionResult Store(mAsociacion model)
        {
            asoc.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateAsoc(mAsociacion model){
            string result = "";
            try{
                if (asoc.modificar(model) == true){
                    result = "Registro actualizado";
                }else{
                    result = "Error al actualizar";
                }
            }
            catch (Exception){
                result = "Error al actualizar";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAsocById(int AsocId)
        {
            List<mAsociacion> model = asoc.mostrarById(AsocId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteAsoc(int AsocId)
        {
            string result = "";
            Asociacion asoci = db.Asociacion.Find(AsocId);
            if (asoci != null)
            {
                asoc.eliminar(AsocId);
                result = "Eliminado";
            }else{
                result = "Registro no encontrado";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
