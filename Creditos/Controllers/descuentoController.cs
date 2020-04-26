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
            ViewBag.persona = clspersona.mostrarcongastos();
            ViewBag.descuentos = clsdescue.mostrar();
            return View();
        }
        public ActionResult indexp(){
            ViewBag.valUsado = clsValUsado.mostrarxEmpleado(4);
            ViewBag.descuentosxE = clsdescue.mostrarxEmpleado(4);
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
        public ActionResult AutoCompleteExternalDataExample2(string term /*our key word*/){
            //items is the source data and can be replaced by a request to a DataBase
            string[] items = {"Test", "Test 1", "Test 2",
        "Example 1", "Example 2", "Example 3"};
            //initialize the list of AutoList object
            List<AutoList> filteredItems = new List<AutoList>();
            int cp = 0;
            foreach (var elem in items){
                if (elem.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0){
                    cp++;
                    //buil our result list
                    AutoList autoList = new AutoList("" + cp, elem);
                    filteredItems.Add(autoList);
                }
            }
            return Json(filteredItems, JsonRequestBehavior.AllowGet);
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
