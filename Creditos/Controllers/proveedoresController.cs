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
    public class proveedoresController : Controller{
        // GET: proveedores
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        clsProveedores clsProvee = new clsProveedores();
        List<mProveedores> list_provee = new List<mProveedores>();
        public ActionResult Index(){
            ViewBag.proveedor = clsProvee.mostrar();
            return View();
        }
        public ActionResult Indexp(){
            ViewBag.proveedor = clsProvee.mostrarProveedor(2);
            return View();
        }
        public ActionResult Store(mProveedores model){
            clsProvee.ingresar(model);
            return RedirectToAction("index");
        }
        
        public JsonResult UpdateProveedores(mProveedores model){
            string result = "";
            try{
                if (clsProvee.modificar(model) == true){
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

        public JsonResult GetProveedoresById(int ProveedoresId)
        {
            List<mProveedores> model = clsProvee.mostrarById(ProveedoresId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings{
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteProveedores(int ProveedoresId){
            string result = "";
            Proveedor proveedor = db.Proveedor.Find(ProveedoresId);
            if (proveedor != null){
                clsProvee.eliminar(ProveedoresId);
                result = "Eliminado";
            }else{
                result = "Registro no encontrado";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
