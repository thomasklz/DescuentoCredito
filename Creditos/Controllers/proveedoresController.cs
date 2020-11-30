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
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsProveedores clsProvee = new clsProveedores();
        clsPersona clsPers = new clsPersona();
        List<mProveedores> list_provee = new List<mProveedores>();

        public ActionResult ValidarSesion(){
                if (Session["proveedor"] != null){
                    
                }else{
                    Response.Redirect("~/login.aspx");
                }
            return View();
        }
        public ActionResult index(){
            ViewBag.proveedor = clsProvee.mostrar();
            return View();
        }
        public ActionResult indexp(){
            ViewBag.proveedor = clsProvee.mostrarProveedor(2);
            return View();
        }
        public ActionResult indexlp(){
            ViewBag.proveedor = clsProvee.mostrarxaso(1);
            return View();
        }
        public ActionResult indexld(){
            ViewBag.personas = clsPers.mostrarvalpen(2);
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
        public ActionResult ValidarProveedor(string _per_jur, string _ruc, string _nombre, string _descr, string _mail, string _dirc, string _telef)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                if (string.IsNullOrEmpty(_per_jur) || string.IsNullOrEmpty(_ruc) || string.IsNullOrEmpty(_nombre) || string.IsNullOrEmpty(_descr) || string.IsNullOrEmpty(_mail) || string.IsNullOrEmpty(_dirc) || string.IsNullOrEmpty(_telef))
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
