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
    public class empleadoAsociacionController : Controller
    {
        // GET: empleadoAsociacion
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsAsociacion clsaso = new clsAsociacion();
        clsPersona clspersona = new clsPersona();
        clsEmpleadoAsociacion clsempl_aso = new clsEmpleadoAsociacion();
        List<mEmpleadoAsociacion> list_em_aso = new List<mEmpleadoAsociacion>();
        public ActionResult Index(){
            ViewBag.asoc = new SelectList(clsaso.mostrar(), "id_asociacion", "descripcion");
            ViewBag.persona = clspersona.mostrarSinAso();
            ViewBag.empl_aso = clsempl_aso.mostrar();
            return View();
        }

        public ActionResult Store(mEmpleadoAsociacion model){
            clsempl_aso.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateEmplAso(mEmpleadoAsociacion model)
        {
            string result = "";
            try{
                if (clsempl_aso.modificar(model) == true){
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

        public JsonResult GetEmplAsoById(int EmplAsoId){
            List<mEmpleadoAsociacion> model = clsempl_aso.mostrarById(EmplAsoId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteEmplAso(int EmplAsoId){
            string result = "";
            empleado_asociacion val_asig = db.empleado_asociacion.Find(EmplAsoId);
            if (val_asig != null){
                clsempl_aso.eliminar(EmplAsoId);
                result = "Eliminado";
            }else{
                result = "Registro no encontrado";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ValidarEmplAso(string _idEmpleado, string _idAsociacion, string _fecha)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                if (string.IsNullOrEmpty(_idEmpleado) || string.IsNullOrEmpty(_idAsociacion) || string.IsNullOrEmpty(_fecha))
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
        public JsonResult SearchPersn(string lastName)
        {
            // clsPersona persona = new clsPersona();
            var output = db.spFiltroPersonaAso(lastName).ToList();
            // return Json(output);
            return Json(output, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ConsultarEmpAsoR(string _idAso)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                int _idAsoEntero = Convert.ToInt32(_idAso);
                var _objAso = clsaso.mostrar().Where(c => c.id_asociacion == _idAsoEntero).FirstOrDefault();
                list_em_aso = clsempl_aso.mostrarRpt(_idAsoEntero);
                var nuevafila = "";
                for (int i = 0; i < list_em_aso.Count; i++)
                {
                    var idNV = list_em_aso[i].id_empl_aso;
                    nuevafila += "<tr class='rows_" + idNV + "'><td colspan='1'><center>" +
                        (i + 1) + "</center></td><td colspan='2'>● " +
                        list_em_aso[i].persona + "</td><td colspan='2'><center> " +
                        list_em_aso[i].fecha_ingreso.ToShortDateString() + "</center></td></tr>";
                }

                string tbody = "<tbody>" + nuevafila +"</tbody>";

                string _tablaFinal = "<table class='table' width='80%' border='1'cellspacing='0' cellpadding='0' style='margin: 0 auto;'>" +
             "<thead>" +
                "<tr>" +
                 "<th colspan='4'><center><img src='../Content/media/logos/espam.jpg' width='50%' height='70%'></center></th> " +
                "</tr> " +
                "<tr>" +
                  "<th colspan='4'><h2><center><br/>LISTADO DE EMPLEADOS ASOCIADOS<br/></center></h2></th>" +
                "</tr> " +
                "<tr>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>Fecha Actual: <br/></b></center></th>" +
                  "<td colspan='1'><center><br/>" + DateTime.Now.ToShortDateString() + "<br/></center></td>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>ASOCIACIÓN: <br/></b></center></th>" +
                  "<td colspan='1'><center><br/>" + _objAso.descripcion.ToUpper() + "<br/></center></td>" +
                 "</tr>" +
                "<tr>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/> Item <br/></b></center></th>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><b><br/>◢ C.C. - EMPLEADO ◣<br/></b></th>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><center><b><br/>FECHA DE UNIÓN<br/></b></center></th>" +
                "</tr>" +
              "</thead>" +
              tbody +
                "</table>";

                _mensaje = "";
                _validar = true;
                return Json(new { mensaje = _mensaje, validar = _validar, tabla = _tablaFinal }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                _mensaje = "<div class='alert alert-danger text-center' role='alert'>ERROR INTERNO DEL SISTEMA: " + ex.Message + "</div>";
            }
            return Json(new { mensaje = _mensaje, validar = _validar }, JsonRequestBehavior.AllowGet);


        }

    }
}
