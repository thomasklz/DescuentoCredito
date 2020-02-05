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
    public class sobranteController : Controller
    {
        // GET: sobrante
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        clsDescuento clsdesc = new clsDescuento();
        clsSobrante clssobra = new clsSobrante();
        List<mSobrante> list_sobra = new List<mSobrante>();
        public ActionResult Index(){
            ViewBag.descu = new SelectList(clsdesc.mostrar(), "id_descuento", "valor");
            ViewBag.sobrante = clssobra.mostrar();
            return View();
        }

        public ActionResult Store(mSobrante model){
            clssobra.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateSobrante(mSobrante model){
            string result = "";
            try{
                if (clssobra.modificar(model) == true){
                    result = "Registro actualizado";
                }else{
                    result = "Error al actualizar";
                }
            }catch (Exception){
                result = "Error al actualizar";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSobranteById(int SobranteId){
            List<mSobrante> model = clssobra.mostrarById(SobranteId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings{
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteSobrante(int SobranteId){
            string result = "";
            Sobrante sobra = db.Sobrante.Find(SobranteId);
            if (sobra != null){
                clssobra.eliminar(SobranteId);
                result = "Eliminado";
            }else{
                result = "Registro no encontrado";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
