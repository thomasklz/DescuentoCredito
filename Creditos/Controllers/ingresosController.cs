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
        BD_AsoRolesCreditos_Entities db = new BD_AsoRolesCreditos_Entities();
        clsMes clsmes = new clsMes();
        clsIngresos clsingreso = new clsIngresos();
        clsTipoIngreso clstipoingresos = new clsTipoIngreso();
        List<mIngresos> list_ingreso = new List<mIngresos>();

        public ActionResult Index() {

            ViewBag.tipoingresos = new SelectList(clstipoingresos.mostrar(), "id_tipo_ingreso", "descripcion");
            ViewBag.mes = new SelectList(clsmes.mostrarMeses(), "id_mes", "descripcion");
            ViewBag.ingresos = clsingreso.mostrar();
            return View();
        }

        //Para la vista del reporte
        public ActionResult Indexr()
        {
            ViewBag.tipoingresos = new SelectList(clstipoingresos.mostrar(), "id_tipo_ingreso", "descripcion");
            ViewBag.mes = new SelectList(clsmes.mostrarMeses(), "id_mes", "descripcion");
            ViewBag.ingresos = clsingreso.mostrar();
            return View();
        }
        //



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


        [HttpPost]
        public ActionResult ConsultarIngreso(string _idMes,string _idIngreso)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                if (string.IsNullOrEmpty(_idMes) || _idMes == "0")
                {
                    _mensaje = "<div class='alert alert-danger text-center' role='alert'>SELECCIONE UN MES</div>";
                }
                else
                {
                    int _idMesEntero = Convert.ToInt32(_idMes);
                    int _idIngresoEntero = Convert.ToInt32(_idIngreso);
                    //int _idTipoIngresoEntero = Convert.ToInt32(_idTipoIngreso); 

                    //var _objTipoIn = clstipoingresos.mostrar().Where(i => i.id_tipo_ingreso == _idTipoIngresoEntero).FirstOrDefault();
                    var _objMes = clsmes.mostrarMeses().Where(c => c.id_mes == _idMesEntero).FirstOrDefault();
                    var _objIngreso = clsingreso.mostrar().Where(i => i.valor == _idIngresoEntero).FirstOrDefault();

                    if (_objMes == null)
                    {
                        _mensaje = "<div class='alert alert-danger text-center' role='alert'>EL MES NO ES VÁLIDO</div>";
                    }
                    else
                    {
                        string _tablaFinal = "<table width='80%' border='1'cellspacing='0' cellpadding='0' style='margin: 0 auto;'>" +
                     "<thead>" +
                        "<tr>" +
                         "<th colspan='4'><img src='../Content/media/logos/espam.png' width='80%' height='120%'></th> " +
                        "</tr> " +
                        "<tr>" +
                          "<th colspan='4'><h2><center><br/>REPORTE DE INGRESOS - AETPAM<br/></center></h2></th>" +
                        "</tr> " +
                        "<tr>" +
                          "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>MES<br/></b></center></th>" +
                          "<td colspan='1'><center><br/>" + _objMes.descripcion.ToUpper() + "<br/></center></td>" +
                          "<th colspan='1' style='background-color:#f7f5f5'><b><br/>ASOCIACIÓN<br/></b></th>" +
                          "<td colspan='1'><center><br/>AETPAM<br/></center></td>" +
                         "</tr>" +
                        "<tr>" +
                          "<th colspan='3' style='background-color:#f7f5f5'><b><br/>TIPO DE INGRESO<br/></b></th>" +
                          "<th colspan='2' style='background-color:#f7f5f5'><b><br/>VALOR<br/></b></th>" +
                        "</tr>" +
                      "</thead>" +

                      "<tbody>" +
                        "<tr>" +
                          //"<td colspan='3'><center><br/>" + _objTipoIn.descripcion.ToUpper() + "<br/></center></td>" +
                          "<td colspan='2'><center><br/>" + _objIngreso.valor + "<br/></center></td>" +
                       "</tr>" +
                       "<tr>" +
                          "<td colspan='3' style='text-align:right; background-color:#f7f5f5'><b><br/>TOTAL<br/></b></td>" +
                          "<td colspan='2' style='background-color:#f7f5f5'><center><b><br/>30,00<br/></b></center></td>" +
                       "</tr>" +
                      "</tbody>" +

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







        }

}

