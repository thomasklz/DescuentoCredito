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
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
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
    }
}
