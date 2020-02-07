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
    public class cabDescuentoController : Controller{
        // GET: cabDescuento
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        clsCabDescuento clscabdesc = new clsCabDescuento();
        clsSubDescuentos clssubdesc = new clsSubDescuentos();
        List<mCabDescuento> list_cabdesc = new List<mCabDescuento>();
        public ActionResult Index()
        {
            ViewBag.subdescuento = new SelectList(clssubdesc.mostrar(), "id_subdescuento", "descripcion");
            ViewBag.listCabDesc = clscabdesc.mostrar();
            return View();
        }

        public ActionResult Store(mCabDescuento model)
        {
            clscabdesc.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateCab_Desc(mCabDescuento model)
        {
            string result = "";
            try
            {
                if (clscabdesc.modificar(model) == true)
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

        public JsonResult GetCab_DescById(int Cab_DescId)
        {
            List<mCabDescuento> model = clscabdesc.mostrarById(Cab_DescId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCab_Desc(int Cab_DescId)
        {
            string result = "";
            Cabecera_Descuento cab_desc = db.Cabecera_Descuento.Find(Cab_DescId);
            if (cab_desc != null)
            {
                clscabdesc.eliminar(Cab_DescId);
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
