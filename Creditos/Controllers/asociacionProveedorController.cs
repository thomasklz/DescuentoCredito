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
    public class asociacionProveedorController : Controller
    {
        // GET: asociacionProveedor
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        clsAsociacion clsaso = new clsAsociacion();
        clsProveedores clsprov = new clsProveedores();
        clsAsociacionProveedor cls_aso_pro = new clsAsociacionProveedor();
        List<mAsociacionProveedor> list_aso_prov = new List<mAsociacionProveedor>();
        public ActionResult Index(){
            ViewBag.asoc = new SelectList(clsaso.mostrar(), "id_asociacion", "descripcion");
            ViewBag.proveedor = clsprov.mostrar();
            ViewBag.aso_prov = cls_aso_pro.mostrar();
            return View();
        }

        public ActionResult Store(mAsociacionProveedor model){
            cls_aso_pro.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateAsoProv(mAsociacionProveedor model)
        {
            string result = "";
            try{
                if (cls_aso_pro.modificar(model) == true){
                    result = "Registro actualizado";
                }else{
                    result = "Error al actualizar";
                }
            }catch (Exception){
                result = "Error al actualizar";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAsoProvById(int AsoProvId)
        {
            List<mAsociacionProveedor> model = cls_aso_pro.mostrarById(AsoProvId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteAsoProv(int AsoProvId){
            string result = "";
            Asociacion_Proveedor aso_prov = db.Asociacion_Proveedor.Find(AsoProvId);
            if (aso_prov != null){
                cls_aso_pro.eliminar(AsoProvId);
                result = "Eliminado";
            }else{
                result = "Registro no encontrado";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
