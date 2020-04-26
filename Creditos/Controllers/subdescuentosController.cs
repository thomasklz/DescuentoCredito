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
    public class subdescuentosController : Controller{

        // GET: subdescuentos
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsSubDescuentos clssubd = new clsSubDescuentos();
        List<mSubDescuentos> lista_subd = new List<mSubDescuentos>();
        public ActionResult Index()
        {
            ViewBag.subdescuento = clssubd.mostrar();
            return View();
        }

        public ActionResult Store(mSubDescuentos model)
        {
            clssubd.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateSubDescuentos(mSubDescuentos model)
        {
            string result = "";
            try
            {
                if (clssubd.modificar(model) == true)
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

        public JsonResult GetSubDescuentosById(int SubDescuentosId)
        {
            List<mSubDescuentos> model = clssubd.mostrarById(SubDescuentosId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteSubDescuentos(int SubDescuentosId)
        {
            string result = "";
            SubDescuento subdescuento = db.SubDescuento.Find(SubDescuentosId);
            if (subdescuento != null)
            {
                clssubd.eliminar(SubDescuentosId);
                result = "Eliminado";
            }
            else
            {
                result = "Registro no encontrado";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ValidarSubdescuento(string _descr){
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try{
                if (string.IsNullOrEmpty(_descr)){
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

    }
}