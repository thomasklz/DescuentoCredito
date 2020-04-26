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
    public class egresosController : Controller
    {
        // GET: egresos
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsMes clsmes = new clsMes();
        clsEgresos clsegreso = new clsEgresos();
        clsTipoEgreso clstipoegresos = new clsTipoEgreso();
        List<mEgresos> list_egreso = new List<mEgresos>();

        public ActionResult Index(){

            ViewBag.tipoegresos = new SelectList(clstipoegresos.mostrar(), "id_tipo_egreso", "descripcion");
            ViewBag.mes = new SelectList(clsmes.mostrarMeses(), "id_mes", "descripcion");
            ViewBag.egresos = clsegreso.mostrar();

            return View();
        }
        
        public ActionResult Store(mEgresos model){

            clsegreso.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateEgresos(mEgresos model){
            string result = "";
            try {
                if (clsegreso.modificar(model) == true){
                    result = "Registro actualizado";
                }
                else{
                    result = "Error al actualizar";
                }
            }
            catch (Exception)
            {
                result = "Error al actualizar";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEgresoById(int EgresoId){
            List<mEgresos> model = clsegreso.mostrarById(EgresoId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings{
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteEgreso(int EgresoId){
            string result = "";
            Egresos egreso = db.Egresos.Find(EgresoId);
            if (egreso != null)
            {
                clsegreso.eliminar(EgresoId);
                result = "Eliminado";
            }
            else
            {
                result = "Registro no encontrado";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ValidarEgreso(string _cant, string _idTipoEgr, string _idMes)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                if (string.IsNullOrEmpty(_cant) || string.IsNullOrEmpty(_idTipoEgr) || string.IsNullOrEmpty(_idMes))
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
