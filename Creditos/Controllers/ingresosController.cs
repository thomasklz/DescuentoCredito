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
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsMes clsmes = new clsMes();
        clsAsociacion clsAso = new clsAsociacion();
        clsCredito clscred = new clsCredito();
        clsIngresos clsingreso = new clsIngresos();
        clsTipoIngreso clstipoingresos = new clsTipoIngreso();
        List<mIngresos> list_ingreso = new List<mIngresos>();
        clsEmpleadoAsociacion empl_aso = new clsEmpleadoAsociacion();

        public ActionResult Index() {
            ViewBag.tipoingresos = new SelectList(clstipoingresos.mostrar(), "id_tipo_ingreso", "descripcion");
            ViewBag.mes = new SelectList(clsmes.mostrarMeses(), "id_mes", "descripcion");
            ViewBag.ingresos = clsingreso.mostrar();
            ViewBag.emp_asos = empl_aso.mostrarRpt(1);
            return View();
        }

        //Para la vista del reporte
        public ActionResult Indexr()
        {
            ViewBag.tipoingresos = new SelectList(clstipoingresos.mostrar(), "id_tipo_ingreso", "descripcion");
            ViewBag.mes = new SelectList(clsmes.mostrarMeses(), "id_mes", "descripcion");
            ViewBag.creditos = clscred.mostraract();
            ViewBag.ingresos = clsingreso.mostrar();
            return View();
        }
        
        public ActionResult Store(mIngresos model) {

            clsingreso.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateIngresos(mIngresos model) {
            string result = "";
            try {
                if (clsingreso.modificar(model) == true) {
                    result = "Registro actualizado";
                }
                else {
                    result = "Error al actualizar";
                }
            }
            catch (Exception) {
                result = "Error al actualizar";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetIngresoById(int IngresoId) {
            List<mIngresos> model = clsingreso.mostrarById(IngresoId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

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
        public ActionResult ValidarIngreso(string _cant, string _idTipoIng, string _idMes)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                if (string.IsNullOrEmpty(_cant) || string.IsNullOrEmpty(_idTipoIng) || string.IsNullOrEmpty(_idMes))
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
        public ActionResult ConsultarIngreso(string _idMes, string _idAso)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            double sum = 0;
            try
            {
                if (string.IsNullOrEmpty(_idMes) || _idMes == "0")
                {
                    _mensaje = "<div class='alert alert-danger text-center' role='alert'>SELECCIONE UN MES</div>";
                }
                else
                {
                    int _idAsoEntero = Convert.ToInt32(_idAso);
                    int _idMesEntero = Convert.ToInt32(_idMes);
                    list_ingreso = clsingreso.mostrarRep(_idMesEntero, _idAsoEntero);
                    var _objMes = clsmes.mostrarMeses().Where(c => c.id_mes == _idMesEntero).FirstOrDefault();
                    var _objAso = clsAso.mostrar().Where(c => c.id_asociacion == _idAsoEntero).FirstOrDefault();
                    var nuevafila = "";
                    for (int i = 0; i < list_ingreso.Count; i++){
                        var idNV = list_ingreso[i].id_ingresos;
                        nuevafila += "<tr class='rows_" + idNV + "'><td colspan='1'><center>" +
                            (i + 1) + "</center></td><td colspan='2'>● " +
                            list_ingreso[i].tipoingreso + "</td><td colspan='2'><center> $ " +
                            list_ingreso[i].valor + "</center></td></tr>";
                        sum = sum + list_ingreso[i].valor;
                    }
                    if (_objMes == null){
                        _mensaje = "<div class='alert alert-danger text-center' role='alert'>EL MES NO ES VÁLIDO</div>";
                    }
                    else
                    {
                        string tbody = "<tbody>"+nuevafila+
                            "<tr>" +
                           "<td colspan='3' style='text-align:right; background-color:#f7f5f5'><b><br/>TOTAL DE INGRESOS ➤ </b></td><br/>" +
                           "<td colspan='2' style='background-color:#f7f5f5'><center><b><br/> $ " + sum + "</b></center></td>" +
                        "</tr></tbody>";

                        string _tablaFinal = "<table class='table' width='80%' border='1'cellspacing='0' cellpadding='0' style='margin: 0 auto;'>" +
                     "<thead>" +
                        "<tr>" +
                         "<th colspan='4'><center><img src='../Content/media/logos/espam.jpg' width='50%' height='70%'></center></th> " +
                        "</tr> " +
                        "<tr>" +
                          "<th colspan='4'><h2><center><br/>REPORTE DE INGRESOS MENSUAL<br/></center></h2></th>" +
                        "</tr> " +
                        "<tr>" +
                          "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>MES: <br/></b></center></th>" +
                          "<td colspan='1'><center><br/>" + _objMes.descripcion.ToUpper() + " - "+ DateTime.Now.Year + "<br/></center></td>" +
                          "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>ASOCIACIÓN: <br/></b></center></th>" +
                          "<td colspan='1'><center><br/>" + _objAso.descripcion.ToUpper() + "<br/></center></td>" +
                         "</tr>" +
                        "<tr>" +
                          "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/> Item <br/></b></center></th>" +
                          "<th colspan='2' style='background-color:#f7f5f5'><b><br/>◢ TIPO DE INGRESO ◣<br/></b></th>" +
                          "<th colspan='2' style='background-color:#f7f5f5'><center><b><br/>VALOR<br/></b></center></th>" +
                        "</tr>" +
                      "</thead>" +
                      tbody+
                        "</table>";

                        _mensaje = "";
                        _validar = true;
                        return Json(new { mensaje = _mensaje, validar = _validar, tabla = _tablaFinal }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                _mensaje = "<div class='alert alert-danger text-center' role='alert'>ERROR INTERNO DEL SISTEMA: " + ex.Message + "</div>";
            }
            return Json(new { mensaje = _mensaje, validar = _validar }, JsonRequestBehavior.AllowGet);


        }
        public ActionResult ConsultarIngresoM(int _idAso)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            double tot = 0;
            try
            {
                int _idAsoEntero = Convert.ToInt32(_idAso);
                var _objAso = clsAso.mostrar().Where(c => c.id_asociacion == _idAsoEntero).FirstOrDefault();
                list_ingreso = clsingreso.mostrarRepM(_idAsoEntero);
                    var nuevafila = "";
                    for (int i = 0; i < list_ingreso.Count; i++)
                    {
                        var idNV = list_ingreso[i].mes_id;
                        nuevafila += "<tr class='rows_" + idNV + "'><td colspan='1'><center>" +
                            (i + 1) + "</center></td><td colspan='2'>● " +
                            list_ingreso[i].mes.ToUpper() + "</td><td colspan='2'><center> $ " +
                            list_ingreso[i].sum + "</center></td></tr>";
                    tot = tot + list_ingreso[i].sum;
                    }

                        string tbody = "<tbody>" + nuevafila +
                            "<tr>" +
                           "<td colspan='3' style='text-align:right; background-color:#f7f5f5'><b><br/>TOTAL DE INGRESOS ➤ </b></td><br/>" +
                           "<td colspan='2' style='background-color:#f7f5f5'><center><b><br/> $ " + tot + "</b></center></td>" +
                        "</tr></tbody>";

                        string _tablaFinal = "<table class='table' width='80%' border='1'cellspacing='0' cellpadding='0' style='margin: 0 auto;'>" +
                     "<thead>" +
                        "<tr>" +
                         "<th colspan='4'><center><img src='../Content/media/logos/espam.jpg' width='50%' height='70%'></center></th> " +
                        "</tr> " +
                        "<tr>" +
                          "<th colspan='4'><h2><center><br/>REPORTE DE INGRESOS ANUAL<br/></center></h2></th>" +
                        "</tr> " +
                        "<tr>" +
                          "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>AÑO: <br/></b></center></th>" +
                          "<td colspan='1'><center><br/>" + DateTime.Now.Year + "<br/></center></td>" +
                          "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>ASOCIACIÓN: <br/></b></center></th>" +
                          "<td colspan='1'><center><br/>" + _objAso.descripcion.ToUpper() + "<br/></center></td>" +
                         "</tr>" +
                        "<tr>" +
                          "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/> Item <br/></b></center></th>" +
                          "<th colspan='2' style='background-color:#f7f5f5'><b><br/>◢ MES ◣<br/></b></th>" +
                          "<th colspan='2' style='background-color:#f7f5f5'><center><b><br/> VALOR <br/></b></center></th>" +
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

