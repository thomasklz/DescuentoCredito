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
    public class proveedorController : Controller
    {
        // GET: proveedor
        AdministracionAcademicaEntities db = new AdministracionAcademicaEntities();
        clsProveedor clsproveedor = new clsProveedor();
        List<mProveedor> list_proveedor = new List<mProveedor>();
        public ActionResult Index()
        {
            ViewBag.proveedores = clsproveedor.mostrar();
            return View();
        }

        public ActionResult Store(mProveedor model)
        {
            clsproveedor.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateProveedor (mProveedor model)
        {
            string result = "";
            try
            {
                if (clsproveedor.modificar(model) == true)
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


        public JsonResult GetProveedorById(int ProveedorId)
        {
            List<mProveedor> model = clsproveedor.mostrarById(ProveedorId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteProveedor (int ProveedorId)
        {
            string result = "";
            Proveedor proveedor = db.Proveedor.Find(ProveedorId);
            if (proveedor != null)
            {
                clsproveedor.eliminar(ProveedorId);
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
