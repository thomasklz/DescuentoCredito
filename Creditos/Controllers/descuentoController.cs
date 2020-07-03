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
        List<mDescuento> list_dsec = new List<mDescuento>();
        List<mValorUtilizado> list_Val = new List<mValorUtilizado>();
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
            ViewBag.descuenxE = clsdescue.mostrarValoresAso();
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

        public ActionResult ConsultarRol(string _idMes, string _idEmpl)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            double sumE = 0;
            try
            {
                if (string.IsNullOrEmpty(_idMes) || _idMes == "0")
                {
                    _mensaje = "<div class='alert alert-danger text-center' role='alert'>SELECCIONE UN MES</div>";
                }
                else
                {
                    int _idEmpEntero = Convert.ToInt32(_idEmpl);
                    int _idMesEntero = Convert.ToInt32(_idMes);
                    var _objPer = clspersona.mostrarRpt(_idEmpEntero);
                    list_Val = clsValUsado.mostrarxEmpleado(_idEmpEntero);  //MODIFICAR PARA QUE SEAN DE ESTE MES
                    list_dsec = clsdescue.mostrarxEmpleado(_idEmpEntero);
                    var _objMes = clsmes.mostrarMeses().Where(c => c.id_mes == _idMesEntero).FirstOrDefault();
                    var nuevafila = "";
                    for (int i = 0; i < list_dsec.Count; i++){
                        var idNV = list_dsec[i].id_descuento;
                        nuevafila +=
                            "<tr>" +
                          "<td colspan='1'></td>" +
                          "<td colspan='2'></td><td colspan='2'></td>" +
                            "<td colspan='2' style='background-color:#f7f5f5'> <center> " +
                            list_dsec[i].cabecera + "</center></td><td colspan='2'><center> $ " +
                            list_dsec[i].valor + "</center></td><td colspan='1'></td></tr>";
                        sumE = sumE + list_dsec[i].valor;
                    }
                    if (_objMes == null)
                    {
                        _mensaje = "<div class='alert alert-danger text-center' role='alert'>EL MES NO ES VÁLIDO</div>";
                    }
                    else
                    {
                        //string tbody = "<tbody>" + nuevafila +
                        //    "<tr>" +
                        //   "<td colspan='3' style='text-align:right; background-color:#f7f5f5'><b><br/>TOTAL DE EGRESOS ➤ </b></td><br/>" +
                        //   "<td colspan='2' style='background-color:#f7f5f5'><center><b><br/> $ " + sum + "</b></center></td>" +
                        //"</tr></tbody>";
                        string encabezado = "<table class='table' width='80%' cellspacing='0' cellpadding='0' style='margin: 0 auto;'>" +
                     "<thead>" +
                        "<tr>" +
                         "<td rowspan='3'><center><img src='../Content/media/logos/espam-1.png' width='30%' height='25%'><center></th> " +
                         "<td colspan='8'><h3><center>ROL DE PAGOS</center></h3></th> " +
                         "<td rowspan='3'><center><img src='../Content/media/logos/tthh.png' width='70%' height='80%'><center></th> " +
                        "</tr> " +
                        "<tr>" +
                          "<td colspan='8'><h5><center>Escuela Superior Politécnica Agropecuaria de Manabí - MFL</center></h5></th>" +
                        "</tr> " +
                        "<tr>" +
                          "<td colspan='8'><h7><center>" + _objMes.descripcion.ToUpper() + " - " + DateTime.Now.Year + "</center></h7></th>" +
                        "</tr></thead></table>";
                        string info = "<table class='table' width='80%' border='1'cellspacing='0' cellpadding='0' style='margin: 0 auto;'>" +
                     "<thead>" +
                        "<tr>" +
                          "<th colspan='10' style='background-color:#BFBFBF'><b>Datos Personales:</b></th>" +
                        "</tr> " +
                        "<tr>" +
                          "<td colspan='1'></td>" +
                          "<td colspan='2' style='background-color:#f7f5f5'>Cédula: </td><td colspan='2'>"+ _objPer.Cedula + "</td>" +
                          "<td colspan='2' style='background-color:#f7f5f5'>Nombre: </td><td colspan='2'>" + _objPer.Nombres + "</td>" +
                          "<td colspan='1'></td></tr><tr><td colspan='1'></td>" +
                          "<td colspan='2' style='background-color:#f7f5f5'>Dirección: </td><td colspan='2'>" + _objPer.Direccion + "</td>" +
                          "<td colspan='2' style='background-color:#f7f5f5'>Teléfono: </td><td colspan='2'>" + _objPer.TelefonoC + "</td>" +
                          "<td colspan='1'></td></tr></td>" +
                        "</tr> " +
                        "<tr>" +
                          "<th colspan='10'></th>" +
                        "</tr> " +
                        "<tr>" +
                          "<th colspan='10' style='background-color:#BFBFBF'><b>Datos Laborales:</b></th>" +
                        "</tr> " +
                        "<tr>" +
                          "<td colspan='1'></td>" +
                          "<td colspan='2' style='background-color:#f7f5f5'>Cargo: </td><td colspan='2'>" + _objPer.nombre_cargo + "</td>" +
                          "<td colspan='2' style='background-color:#f7f5f5'>Tipo de Contrato: </td><td colspan='2'>" + _objPer.tipo_cont + "</td>" +
                          "<td colspan='1'></td>" +
                        "</tr>" +
                        "<tr>" +
                          "<td colspan='1'></td>" +
                          "<td colspan='2' style='background-color:#f7f5f5'>N° Cuenta: </td><td colspan='2'>" + _objPer.n_cuenta + "</td>" +
                          "<td colspan='2' style='background-color:#f7f5f5'>Banco: </td><td colspan='2'>" + _objPer.banco + "</td>" +
                          "<td colspan='1'></td>" +
                        "</tr> " +
                      "</thead>" +
                      "<tbody>" +
                        "<tr>" +
                          "<th colspan='10'><br/></th>" +
                        "</tr> " +
                        "<tr>" +
                          "<td colspan='1'></td>" +
                          "<td colspan='4' style='background-color:#f7f5f5'><h4><center><b><br/> INGRESOS </b></center></h4></td>" +
                          "<td colspan='4' style='background-color:#f7f5f5'><h4><center><b><br/> DESCUENTOS </b></center></h4></td>" +
                          "<td colspan='1'></td>" +
                        "</tr> " +
                        "<tr>" +
                          "<td colspan='1'></td>" +
                          "<td colspan='2' style='background-color:#f7f5f5'><center> Salario: </center></td><td colspan='2'><center> $ " + _objPer.salario + "</center></td>" +
                          //"<td colspan='2' style='background-color:#f7f5f5'><center> Préstamo: </center></td><td colspan='2'><center> $ 269 </center></td>" +
                          nuevafila +
                          "<td colspan='1'></td>" +
                        "</tr> " +
                        "<tr>" +
                          "<td colspan='1'></td>" +
                          "<td colspan='4' style='background-color:#f7f5f5'><b> TOTAL DE INGRESOS: $ " + _objPer.salario + "</b></td>" +
                          "<td colspan='4' style='background-color:#f7f5f5'><b> TOTAL DE DESCUENTOS: $ " + sumE + "</b></td>" +
                          "<td colspan='1'></td>" +
                        "</tr> " +
                        "<tr>" +
                          "<th colspan='10'></th>" +
                        "</tr> " +
                        "<tr>" +
                          "<th colspan='10' style='background-color:#BFBFBF'><h5><b><center> TOTAL A RECIBIR: $ " + (_objPer.salario - sumE) + "</center></b></h5></th>" +
                        "</tr> " +
                        "<tr>" +
                          "<th colspan='10'><br/><br/></th>" +
                        "</tr> " +
                      "</tbody>" +
                      "</table>";

                        _mensaje = "";
                        _validar = true;
                        string _tablaFinal = encabezado + info;
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
