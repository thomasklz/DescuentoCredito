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
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsMes clsmes = new clsMes();
        clsCabDescuento clscabec = new clsCabDescuento();
        clsPersona clspersona = new clsPersona();
        clsDescuento clsdescue = new clsDescuento();
        clsValorUtilizado clsValUsado = new clsValorUtilizado();
        List<mDescuento> list_ingreso = new List<mDescuento>();
        public ActionResult index(){
            ViewBag.cabecera = new SelectList(clscabec.mostrar(), "id_cabecera_descuento", "descripcion");
            ViewBag.mes = new SelectList(clsmes.mostrarMeses(), "id_mes", "descripcion");
            ViewBag.descuentos = clsdescue.mostrar();
            return View();
        }
        public ActionResult indexp(){
            ViewBag.valUsado = clsValUsado.mostrarxEmpleado(4);
            ViewBag.descuentosxE = clsdescue.mostrarxEmpleado(4);
            return View();
        }
        public ActionResult indexa(){
            ViewBag.descuentosxE = clsdescue.mostrarValoresAso();
            return View();
        }
        public ActionResult indexr(){
            ViewBag.mes = new SelectList(clsmes.mostrarMeses(), "id_mes", "descripcion");
            return View();
        }
        public ActionResult indexrol(){
            ViewBag.mes = new SelectList(clsmes.mostrarMeses(), "id_mes", "descripcion");
            return View();
        }
        public ActionResult Store(mDescuento model){
            
            clsdescue.ingresar(model);
            return RedirectToAction("index");
        }
        public ActionResult Storea(mDescuento model){

            clsdescue.ingresarxAjuste(model);
            return RedirectToAction("indexa");
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
        public ActionResult ValidarDescuento(string _fecha, string _idEmpleado, string _idMes, string _cabDesc, string _cant)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                if (string.IsNullOrEmpty(_fecha) || string.IsNullOrEmpty(_idEmpleado) || string.IsNullOrEmpty(_idMes) || string.IsNullOrEmpty(_cabDesc) || string.IsNullOrEmpty(_cant))
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

        [HttpPost]
        public JsonResult SearchPerson(string lastName){
            // clsPersona persona = new clsPersona();
            var output = db.spFiltroPersona(lastName).ToList();
           // return Json(output);
            return Json(output, JsonRequestBehavior.AllowGet);
        }

    }
}
