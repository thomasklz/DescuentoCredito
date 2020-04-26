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
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
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
        public ActionResult ValidarAsoProv(string _idProveedor, string _idAsociacion, string _fecha)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                if (string.IsNullOrEmpty(_idProveedor) || string.IsNullOrEmpty(_idAsociacion) || string.IsNullOrEmpty(_fecha))
                {
                    _mensaje = "<div class='alert alert-danger text-center' role='alert'>Ingrese todos los datos</div>";
                }
                else
                {
                    _mensaje = "";
                    _validar = true;
                    return Json(new { mensaje = _mensaje, validar = _validar }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                _mensaje = "<div class='alert alert-danger text-center' role='alert'>ERROR INTERNO DEL SISTEMA: " + ex.Message + "</div>";
            }
            return Json(new { mensaje = _mensaje, validar = _validar }, JsonRequestBehavior.AllowGet);
        }
    }
}
