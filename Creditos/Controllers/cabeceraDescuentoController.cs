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
    public class cabeceraDescuentoController : Controller
    {
        // GET: cabeceraDescuento
        AdministracionAcademicaEntities db = new AdministracionAcademicaEntities();
        clsSubDescuento clsdesc = new clsSubDescuento();
        clsCabeceraDescuento clscabdesc = new clsCabeceraDescuento();
        List<mCabeceraDescuento> list_cab_desc = new List<mCabeceraDescuento>();

        public ActionResult Index(){
            ViewBag.descuentos = new SelectList(clsdesc.mostrar(), "id_subdescuento", "descripcion");
            ViewBag.cab_desc = clscabdesc.mostrar();
            return View();
        }

        public ActionResult Store(mCabeceraDescuento model){
            clscabdesc.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateCabDesc(mCabeceraDescuento model){
            string result = "";
            try{
                if (clscabdesc.modificar(model) == true){
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


        public JsonResult GetCabDescById(int CabDescId){
            List<mCabeceraDescuento> model = clscabdesc.mostrarById(CabDescId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings{
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteCabDesc(int CabDescId){
            string result = "";
            Cabecera_Descuento cab_desc = db.Cabecera_Descuento.Find(CabDescId);
            if (cab_desc != null){
                clscabdesc.eliminar(CabDescId);
                result = "Eliminado";
            }
            else{
                result = "Registro no encontrado";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}
