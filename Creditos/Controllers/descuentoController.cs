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
    public class descuentoController : Controller{
        // GET: descuento
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        clsMes clsmes = new clsMes();
        clsCabDescuento clscabec = new clsCabDescuento();
        clsPersona clspersona = new clsPersona();
        clsDescuento clsdescue = new clsDescuento();
        List<mDescuento> list_ingreso = new List<mDescuento>();
        public ActionResult Index(){
            ViewBag.cabecera = new SelectList(clscabec.mostrar(), "id_cabecera_descuento", "descripcion");
            ViewBag.mes = new SelectList(clsmes.mostrarMeses(), "id_mes", "descripcion");
            ViewBag.persona = new SelectList(clspersona.mostrar(), "Id_Persona", "Nombres");
            ViewBag.descuentos = clsdescue.mostrar();
            return View();
        }

        public ActionResult Store(mDescuento model){
            clsdescue.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateDescuentos(mDescuento model){
            string result = "";
            try{
                if (clsdescue.modificar(model) == true){
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

        public JsonResult GetDescuentoById(int DescuentoId){
            List<mDescuento> model = clsdescue.mostrarById(DescuentoId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteDescuento(int DescuentoId){
            string result = "";
            Descuento descuento = db.Descuento.Find(DescuentoId);
            if (descuento != null){
                clsdescue.eliminar(DescuentoId);
                result = "Eliminado";
            }else{
                result = "Registro no encontrado";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
