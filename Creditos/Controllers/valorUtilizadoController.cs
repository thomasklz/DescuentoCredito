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
    public class valorUtilizadoController : Controller
    {
        // GET: valorUtilizado
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsMes clsmes = new clsMes();
        clsValorAsignado clsvalorasig = new clsValorAsignado();
        clsValorUtilizado clsvalorutil = new clsValorUtilizado();
        List<mValorUtilizado> list_valor = new List<mValorUtilizado>();
        public ActionResult Index(){
            ViewBag.val_asig = clsvalorasig.mostrarEnAso(2);
            ViewBag.mes = new SelectList(clsmes.mostrarMeses(), "id_mes", "descripcion");
            ViewBag.val_util = clsvalorutil.mostrarxProv(2);
            return View();
        }

        public ActionResult Store(mValorUtilizado model){
            clsvalorutil.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateValUsado(mValorUtilizado model){
            string result = "";
            try{
                if (clsvalorutil.modificar(model) == true){
                    result = "Registro actualizado";
                }else{
                    result = "Error al actualizar";
                }
            }catch (Exception){
                result = "Error al actualizar";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetValUsadoById(int ValUsadoId){
            List<mValorUtilizado> model = clsvalorutil.mostrarById(ValUsadoId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteValUsado(int ValUsadoId){
            string result = "";
            Valor_Utilizado val_usad = db.Valor_Utilizado.Find(ValUsadoId);
            if (val_usad != null){
                clsvalorutil.eliminar(ValUsadoId);
                result = "Eliminado";
            }
            else{
                result = "Registro no encontrado";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ValidarValorUtil(string _idValorAsign, string _idMes, string _cantidad){
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try{
                if (string.IsNullOrEmpty(_idValorAsign) || string.IsNullOrEmpty(_idMes) || string.IsNullOrEmpty(_cantidad)){
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
