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
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
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

        //public JsonResult UpdateValAsignado(mValorUtilizado model)
        //{
        //    string result = "";
        //    try
        //    {
        //        if (clsvalorasig.modificar(model) == true)
        //        {
        //            result = "Registro actualizado";
        //        }
        //        else
        //        {
        //            result = "Error al actualizar";
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        result = "Error al actualizar";
        //    }
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult GetValAsignadoById(int ValAsignadoId)
        //{
        //    List<mValorUtilizado> model = clsvalorasig.mostrarById(ValAsignadoId);
        //    string value = string.Empty;
        //    value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
        //    {
        //        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //    });
        //    return Json(value, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult DeleteValAsignado(int ValAsignadoId)
        //{
        //    string result = "";
        //    Valor_Asignado val_asig = db.Valor_Asignado.Find(ValAsignadoId);
        //    if (val_asig != null)
        //    {
        //        clsvalorasig.eliminar(ValAsignadoId);
        //        result = "Eliminado";
        //    }
        //    else
        //    {
        //        result = "Registro no encontrado";
        //    }
        //    return Json(result, JsonRequestBehavior.AllowGet);
        //}
    }
}
