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
    public class ingresosController : Controller
    {
        // GET: ingresos
        AdministracionAcademicaEntities db = new AdministracionAcademicaEntities();
        clsMes clsmes = new clsMes();
        clsIngresos clsingreso = new clsIngresos();
        clsTipoIngreso clstipoingresos = new clsTipoIngreso();
        List<mIngresos> list_ingreso = new List<mIngresos>();
        //public ActionResult Index(){

        //    ViewBag.tipoingresos = new SelectList(clstipoingresos.mostrar(), "id_tipo_ingreso", "descripcion");
        //    ViewBag.mes = new SelectList(clsmes.mostrarMeses(), "id_mes", "descripcion");
        //    ViewBag.ingresos = clsingreso.mostrar();
          
        //    return View();
        //}

        public ActionResult Store(mIngresos model) {

            clsingreso.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateIngresos(mIngresos model){
            string result = "";
            try{
                if (clsingreso.modificar(model) == true){
                    result = "Registro actualizado";
                }
                else {
                    result = "Error al actualizar";
                }
            }
            catch (Exception){
                result = "Error al actualizar";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        //public JsonResult GetIngresoById(int IngresoId)
        //{
        //    List<mIngresos> model = clsingreso.mostrarById(IngresoId);
        //    string value = string.Empty;
        //    value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //    });
        //    return Json(value, JsonRequestBehavior.AllowGet);
        //}


        public JsonResult DeleteIngreso(int IngresoId)
        {
            string result = "";
             Ingresos ingreso = db.Ingresos.Find(IngresoId);
            if (ingreso != null)
            {
                clsingreso.eliminar(IngresoId);
                result = "Eliminado";
            }
            else {
                result = "Registro no encontrado";
            }
        
            return Json(result, JsonRequestBehavior.AllowGet);
        }


    }
}
