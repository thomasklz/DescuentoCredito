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
    public class tipoIngresosController : Controller
    {
        // GET: tipoIngresos
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        clsTipoIngresos tipoin = new clsTipoIngresos();
        List<mTipoIngreso> list_tipoi = new List<mTipoIngreso>();
        public ActionResult Index()
        {
            ViewBag.tipoingreso = tipoin.mostrar();
            return View();
        }

        public ActionResult Store(mTipoIngreso model)
        {
            tipoin.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateTipoIngresos(mTipoIngreso model)
        {
            string result = "";
            try
            {
                if (tipoin.modificar(model) == true)
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

        public JsonResult GetTipoIngresosById(int TipoIngresoId)
        {
            List<mTipoIngreso> model = tipoin.mostrarById(TipoIngresoId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteTipoIngresos(int TipoIngresoId)
        {
            string result = "";
            Tipo_ingreso tipoingreso = db.Tipo_ingreso.Find(TipoIngresoId);
            if (tipoingreso != null)
            {
                tipoin.eliminar(TipoIngresoId);
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
