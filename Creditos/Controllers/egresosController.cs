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
    public class egresosController : Controller
    {
        // GET: egresos
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsMes clsmes = new clsMes();
        clsEgresos clsegreso = new clsEgresos();
        clsTipoEgreso clstipoegresos = new clsTipoEgreso();
        List<mEgresos> list_egreso = new List<mEgresos>();

        public ActionResult Index(){

            ViewBag.tipoegresos = new SelectList(clstipoegresos.mostrar(), "id_tipo_egreso", "descripcion");
            ViewBag.mes = new SelectList(clsmes.mostrarMeses(), "id_mes", "descripcion");
            ViewBag.egresos = clsegreso.mostrar();

            return View();
        }
        
        public ActionResult Store(mEgresos model){

            clsegreso.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateEgresos(mEgresos model){
            string result = "";
            try {
                if (clsegreso.modificar(model) == true){
                    result = "Registro actualizado";
                }
                else{
                    result = "Error al actualizar";
                }
            }
            catch (Exception)
            {
                result = "Error al actualizar";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetEgresoById(int EgresoId){
            List<mEgresos> model = clsegreso.mostrarById(EgresoId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings{
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteEgreso(int EgresoId){
            string result = "";
            Egresos egreso = db.Egresos.Find(EgresoId);
            if (egreso != null)
            {
                clsegreso.eliminar(EgresoId);
                result = "Eliminado";
            }
            else
            {
                result = "Registro no encontrado";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ValidarEgreso(string _cant, string _idTipoEgr, string _idMes)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                if (string.IsNullOrEmpty(_cant) || string.IsNullOrEmpty(_idTipoEgr) || string.IsNullOrEmpty(_idMes))
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
        public ActionResult ConsultarEgreso(string _idMes)
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
                    int _idMesEntero = Convert.ToInt32(_idMes);
                    list_egreso = clsegreso.mostrarRep(Convert.ToInt32(_idMes), 1);
                    var _objMes = clsmes.mostrarMeses().Where(c => c.id_mes == _idMesEntero).FirstOrDefault();
                    var nuevafila = "";
                    for (int i = 0; i < list_egreso.Count; i++)
                    {
                        var idNV = list_egreso[i].id_egresos;
                        nuevafila += "<tr class='rows_" + idNV + "'><td colspan='1'><center>" +
                            (i + 1) + "</center></td><td colspan='2'>● " +
                            list_egreso[i].tipoegreso + "</td><td colspan='2'><center> $ " +
                            list_egreso[i].valor + "</center></td></tr>";
                        sum = sum + list_egreso[i].valor;
                    }
                    if (_objMes == null)
                    {
                        _mensaje = "<div class='alert alert-danger text-center' role='alert'>EL MES NO ES VÁLIDO</div>";
                    }
                    else
                    {
                        string tbody = "<tbody>" + nuevafila +
                            "<tr>" +
                           "<td colspan='3' style='text-align:right; background-color:#f7f5f5'><b><br/>TOTAL DE EGRESOS ➤ </b></td><br/>" +
                           "<td colspan='2' style='background-color:#f7f5f5'><center><b><br/> $ " + sum + "</b></center></td>" +
                        "</tr></tbody>";

                        string _tablaFinal = "<table class='table' width='80%' border='1'cellspacing='0' cellpadding='0' style='margin: 0 auto;'>" +
                     "<thead>" +
                        "<tr>" +
                         "<th colspan='4'><center><img src='../Content/media/logos/espam.png' width='80%' height='120%'></center></th> " +
                        "</tr> " +
                        "<tr>" +
                          "<th colspan='4'><h2><center><br/>REPORTE DE EGRESOS<br/></center></h2></th>" +
                        "</tr> " +
                        "<tr>" +
                          "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>MES<br/></b></center></th>" +
                          "<td colspan='1'><center><br/>" + _objMes.descripcion.ToUpper() + " - " + DateTime.Now.Year + "<br/></center></td>" +
                          "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>ASOCIACIÓN<br/></b></center></th>" +
                          "<td colspan='1'><center><br/>AETPAM<br/></center></td>" +
                         "</tr>" +
                        "<tr>" +
                          "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/> Item <br/></b></center></th>" +
                          "<th colspan='2' style='background-color:#f7f5f5'><b><br/>◢TIPO DE EGRESO◣<br/></b></th>" +
                          "<th colspan='2' style='background-color:#f7f5f5'><center><b><br/>VALOR<br/></b></center></th>" +
                        "</tr>" +
                      "</thead>" +
                      tbody +
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
        public ActionResult ConsultarEgresosM()
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            double tot = 0;
            try
            {
                list_egreso = clsegreso.mostrarRepM(1);
                var nuevafila = "";
                for (int i = 0; i < list_egreso.Count; i++)
                {
                    var idNV = list_egreso[i].mes_id;
                    nuevafila += "<tr class='rows_" + idNV + "'><td colspan='1'><center>" +
                        (i + 1) + "</center></td><td colspan='2'>● " +
                        list_egreso[i].mes.ToUpper() + "</td><td colspan='2'><center> $ " +
                        list_egreso[i].sum + "</center></td></tr>";
                    tot = tot + list_egreso[i].sum;
                }

                string tbody = "<tbody>" + nuevafila +
                    "<tr>" +
                   "<td colspan='3' style='text-align:right; background-color:#f7f5f5'><b><br/>TOTAL DE EGRESOS ➤ </b></td><br/>" +
                   "<td colspan='2' style='background-color:#f7f5f5'><center><b><br/> $ " + tot + "</b></center></td>" +
                "</tr></tbody>";

                string _tablaFinal = "<table class='table' width='80%' border='1'cellspacing='0' cellpadding='0' style='margin: 0 auto;'>" +
             "<thead>" +
                "<tr>" +
                 "<th colspan='4'><center><img src='../Content/media/logos/espam.png' width='80%' height='120%'></center></th> " +
                "</tr> " +
                "<tr>" +
                  "<th colspan='4'><h2><center><br/>REPORTE DE EGRESOS ANUAL<br/></center></h2></th>" +
                "</tr> " +
                "<tr>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>AÑO<br/></b></center></th>" +
                  "<td colspan='1'><center><br/>" + DateTime.Now.Year + "<br/></center></td>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>ASOCIACIÓN<br/></b></center></th>" +
                  "<td colspan='1'><center><br/>AETPAM<br/></center></td>" +
                 "</tr>" +
                "<tr>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/> Item <br/></b></center></th>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><b><br/>◢ MES ◣<br/></b></th>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><center><b><br/>VALOR<br/></b></center></th>" +
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
