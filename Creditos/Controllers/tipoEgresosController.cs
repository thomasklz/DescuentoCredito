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
    public class tipoEgresosController : Controller
    {
        // GET: tipoEgresos
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsTipoEgresos tipoeg = new clsTipoEgresos();
        List<mTipoEgreso> list_tipoe = new List<mTipoEgreso>();
        public ActionResult Index()
        {
            ViewBag.tipoegreso = tipoeg.mostrar();
            return View();
        }

        public ActionResult Store(mTipoEgreso model)
        {
            tipoeg.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateTipoEgresos(mTipoEgreso model)
        {
            string result = "";
            try
            {
                if (tipoeg.modificar(model) == true)
                {
                    result = "Registro actualizado";
                }
                else
                {
                    result = "Error al actualizar";
                }
            }
            catch (Exception)
            {
                result = "Error al actualizar";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetTipoEgresosById(int TipoEgresoId)
        {
            List<mTipoEgreso> model = tipoeg.mostrarById(TipoEgresoId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteTipoEgresos(int TipoEgresoId)
        {
            string result = "";
            Tipo_egreso tipoegreso = db.Tipo_egreso.Find(TipoEgresoId);
            if (tipoegreso != null)
            {
                tipoeg.eliminar(TipoEgresoId);
                result = "Eliminado";
            }
            else
            {
                result = "Registro no encontrado";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ValidarTipoEgreso(string _descr)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                if (string.IsNullOrEmpty(_descr))
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
