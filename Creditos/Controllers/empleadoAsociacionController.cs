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
    public class empleadoAsociacionController : Controller
    {
        // GET: empleadoAsociacion
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        clsAsociacion clsaso = new clsAsociacion();
        clsPersona clspersona = new clsPersona();
        clsEmpleadoAsociacion clsempl_aso = new clsEmpleadoAsociacion();
        List<mEmpleadoAsociacion> list_em_aso = new List<mEmpleadoAsociacion>();
        public ActionResult Index(){
            ViewBag.asoc = new SelectList(clsaso.mostrar(), "id_asociacion", "descripcion");
            ViewBag.persona = clspersona.mostrarSinAso();
            ViewBag.empl_aso = clsempl_aso.mostrar();
            return View();
        }

        public ActionResult Store(mEmpleadoAsociacion model){
            clsempl_aso.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateEmplAso(mEmpleadoAsociacion model)
        {
            string result = "";
            try{
                if (clsempl_aso.modificar(model) == true){
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

        public JsonResult GetEmplAsoById(int EmplAsoId){
            List<mEmpleadoAsociacion> model = clsempl_aso.mostrarById(EmplAsoId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteEmplAso(int EmplAsoId){
            string result = "";
            empleado_asociacion val_asig = db.empleado_asociacion.Find(EmplAsoId);
            if (val_asig != null){
                clsempl_aso.eliminar(EmplAsoId);
                result = "Eliminado";
            }else{
                result = "Registro no encontrado";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
