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
    public class tipoEgresosController : Controller
    {
        // GET: tipoEgresos
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        clsTipoEgresos tipoeg = new clsTipoEgresos();
        List<mTipoEgreso> list_tipoe = new List<mTipoEgreso>();
        public ActionResult Index()
        {
            ViewBag.tipoegreso = tipoeg.mostrar();
            return View();
        }

        public ActionResult Store(mTipoEgreso model)
        {
            tipoeg.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateTipoEgresos(mTipoEgreso model)
        {
            string result = "";
            try
            {
                if (tipoeg.modificar(model) == true)
                {
                    result = "Registro actualizado";
                }
                else
                {
                    result = "Error al actualizar";
                }
            }
            catch (Exception)
            {
                result = "Error al actualizar";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTipoEgresosById(int TipoEgresoId)
        {
            List<mTipoEgreso> model = tipoeg.mostrarById(TipoEgresoId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteTipoEgresos(int TipoEgresoId)
        {
            string result = "";
            Tipo_egreso tipoegreso = db.Tipo_egreso.Find(TipoEgresoId);
            if (tipoegreso != null)
            {
                tipoeg.eliminar(TipoEgresoId);
                result = "Eliminado";
            }
            else
            {
                result = "Registro no encontrado";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
