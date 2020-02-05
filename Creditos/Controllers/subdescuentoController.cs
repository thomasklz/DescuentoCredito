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
    public class subdescuentoController : Controller
    {
        // GET: subdescuento
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsSubDescuento clssubdescuento = new clsSubDescuento();
        List<mSubDesuento> list_subdescuento = new List<mSubDesuento>();
        public ActionResult Index()
        {
            ViewBag.subdescuentos = clssubdescuento.mostrar();
            return View();
        }

        public ActionResult Store(mSubDesuento model)
        {
            clssubdescuento.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateSubDescuento(mSubDesuento model)
        {
            string result = "";
            try
            {
                if (clssubdescuento.modificar(model) == true)
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


        public JsonResult GetSubDescuentoById(int SubDescuentoId)
        {
            List<mSubDesuento> model = clssubdescuento.mostrarById(SubDescuentoId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteSubDescuento(int SubDescuentoId)
        {
            string result = "";
            SubDescuento subdescuento = db.SubDescuento.Find(SubDescuentoId);
            if (subdescuento != null)
            {
                clssubdescuento.eliminar(SubDescuentoId);
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