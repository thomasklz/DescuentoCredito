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
    public class subdescuentosController : Controller{

        // GET: subdescuentos
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        clsSubDescuentos clssubd = new clsSubDescuentos();
        List<mSubDescuentos> lista_subd = new List<mSubDescuentos>();
        public ActionResult Index()
        {
            ViewBag.subdescuento = clssubd.mostrar();
            return View();
        }

        public ActionResult Store(mSubDescuentos model)
        {
            clssubd.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateSubDescuentos(mSubDescuentos model)
        {
            string result = "";
            try
            {
                if (clssubd.modificar(model) == true)
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

        public JsonResult GetSubDescuentosById(int SubDescuentosId)
        {
            List<mSubDescuentos> model = clssubd.mostrarById(SubDescuentosId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteSubDescuentos(int SubDescuentosId)
        {
            string result = "";
            SubDescuento subdescuento = db.SubDescuento.Find(SubDescuentosId);
            if (subdescuento != null)
            {
                clssubd.eliminar(SubDescuentosId);
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