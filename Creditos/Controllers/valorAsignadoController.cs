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
    public class valorAsignadoController : Controller{
        // GET: ValorAsignado
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsAsociacionProveedor clsprovee = new clsAsociacionProveedor();
        clsEmpleadoAsociacion clsemp_aso = new clsEmpleadoAsociacion();
        clsValorAsignado clsvalorasig = new clsValorAsignado();
        List<mValorAsignado> list_valor = new List<mValorAsignado>();
        public ActionResult Index(){
            ViewBag.proveedor = clsprovee.mostrar();
            ViewBag.persona = clsemp_aso.mostrar();
            ViewBag.val_asig = clsvalorasig.mostrar();
            return View();
        }

        public ActionResult Store(mValorAsignado model){
            clsvalorasig.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateValAsignado(mValorAsignado model){
            string result = "";
            try{
                if (clsvalorasig.modificar(model) == true){
                    result = "Registro actualizado";
                }else{
                    result = "Error al actualizar";
                }
            }catch (Exception){
                result = "Error al actualizar";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetValAsignadoById(int ValAsignadoId){
            List<mValorAsignado> model = clsvalorasig.mostrarById(ValAsignadoId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteValAsignado(int ValAsignadoId){
            string result = "";
            Valor_Asignado val_asig = db.Valor_Asignado.Find(ValAsignadoId);
            if (val_asig != null){
                clsvalorasig.eliminar(ValAsignadoId);
                result = "Eliminado";
            }else{
                result = "Registro no encontrado";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ValidarValAsig(string _idProveedor, string _idAsociacion, string _idEmpleado, string _montoAprobado){
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try{
                if (string.IsNullOrEmpty(_idProveedor) || string.IsNullOrEmpty(_idAsociacion) || string.IsNullOrEmpty(_idEmpleado) || string.IsNullOrEmpty(_montoAprobado)){
                    _mensaje = "<div class='alert alert-danger text-center' role='alert'>Ingrese todos los datos</div>";
                }else{
                    _mensaje = "";
                    _validar = true;
                    return Json(new { mensaje = _mensaje, validar = _validar }, JsonRequestBehavior.AllowGet);
                }
            }catch (Exception ex){
                _mensaje = "<div class='alert alert-danger text-center' role='alert'>ERROR INTERNO DEL SISTEMA: " + ex.Message + "</div>";
            }
            return Json(new { mensaje = _mensaje, validar = _validar }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchPerson(string lastName){
            // clsPersona persona = new clsPersona();
            var output = db.spFiltroAsoEmpl(lastName).ToList();
            // return Json(output);
            return Json(output, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SearchProv(string lastName){
            // clsPersona persona = new clsPersona();
            var output = db.spFiltroAsoProv(lastName).ToList();
            // return Json(output);
            return Json(output, JsonRequestBehavior.AllowGet);
        }
    }
}
