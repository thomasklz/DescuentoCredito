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
    public class asociacionProveedorController : Controller
    {
        // GET: asociacionProveedor
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsAsociacion clsaso = new clsAsociacion();
        clsProveedores clsprov = new clsProveedores();
        clsAsociacionProveedor cls_aso_pro = new clsAsociacionProveedor();
        List<mAsociacionProveedor> list_aso_prov = new List<mAsociacionProveedor>();
        public ActionResult Index(){
            ViewBag.asoc = new SelectList(clsaso.mostrar(), "id_asociacion", "descripcion");
            ViewBag.proveedor = clsprov.mostrar();
            ViewBag.aso_prov = cls_aso_pro.mostrar();
            return View();
        }

        public ActionResult Store(mAsociacionProveedor model){
            cls_aso_pro.ingresar(model);
            return RedirectToAction("index");
        }

        public JsonResult UpdateAsoProv(mAsociacionProveedor model)
        {
            string result = "";
            try{
                if (cls_aso_pro.modificar(model) == true){
                    result = "Registro actualizado";
                }else{
                    result = "Error al actualizar";
                }
            }catch (Exception){
                result = "Error al actualizar";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAsoProvById(int AsoProvId)
        {
            List<mAsociacionProveedor> model = cls_aso_pro.mostrarById(AsoProvId);
            string value = string.Empty;
            value = JsonConvert.SerializeObject(model, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Json(value, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteAsoProv(int AsoProvId){
            string result = "";
            Asociacion_Proveedor aso_prov = db.Asociacion_Proveedor.Find(AsoProvId);
            if (aso_prov != null){
                cls_aso_pro.eliminar(AsoProvId);
                result = "Eliminado";
            }else{
                result = "Registro no encontrado";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ValidarAsoProv(string _idProveedor, string _idAsociacion, string _fecha)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                if (string.IsNullOrEmpty(_idProveedor) || string.IsNullOrEmpty(_idAsociacion) || string.IsNullOrEmpty(_fecha))
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
        public JsonResult SearchProv(string lastName){
            // clsPersona persona = new clsPersona();
            var output = db.spFiltroProveedor(lastName).ToList();
            // return Json(output);
            return Json(output, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ConsultarAsoProvR(string _idAso)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                int _idAsoEntero = Convert.ToInt32(_idAso);
                var _objAso = clsaso.mostrar().Where(c => c.id_asociacion == _idAsoEntero).FirstOrDefault();
                list_aso_prov = cls_aso_pro.mostrarRpt(_idAsoEntero);
                var nuevafila = "";
                for (int i = 0; i < list_aso_prov.Count; i++)
                {
                    var idNV = list_aso_prov[i].id_asoc_prov;
                    nuevafila += "<tr class='rows_" + idNV + "'><td colspan='1'><center>" +
                        (i + 1) + "</center></td><td colspan='2'>● " +
                        list_aso_prov[i].proveedor + "</td><td colspan='2'><center> " +
                        list_aso_prov[i].fecha.ToShortDateString() + "</center></td></tr>";
                }

                string tbody = "<tbody>" + nuevafila + "</tbody>";

                string _tablaFinal = "<table class='table' width='80%' border='1'cellspacing='0' cellpadding='0' style='margin: 0 auto;'>" +
             "<thead>" +
                "<tr>" +
                 "<th colspan='4'><center><img src='../Content/media/logos/espam.jpg' width='50%' height='70%'></center></th> " +
                "</tr> " +
                "<tr>" +
                  "<th colspan='4'><h2><center><br/>LISTADO DE PROVEEDORES ASOCIADOS<br/></center></h2></th>" +
                "</tr> " +
                "<tr>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>Fecha Actual: <br/></b></center></th>" +
                  "<td colspan='1'><center><br/>" + DateTime.Now.ToShortDateString() + "<br/></center></td>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>ASOCIACIÓN: <br/></b></center></th>" +
                  "<td colspan='1'><center><br/>" + _objAso.descripcion.ToUpper() + "<br/></center></td>" +
                 "</tr>" +
                "<tr>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/> Item <br/></b></center></th>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><b><br/>◢ RUC - PROVEEEDOR ◣<br/></b></th>" +
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
        public ActionResult ConsultarinfoPagoR(string _idAso)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                int _idAsoEntero = Convert.ToInt32(_idAso);
                var _objAso = clsaso.mostrar().Where(c => c.id_asociacion == _idAsoEntero).FirstOrDefault();
                list_aso_prov = cls_aso_pro.mostrarInPg(_idAsoEntero);
                var nuevafila = "";
                for (int i = 0; i < list_aso_prov.Count; i++)
                {
                    var idNV = list_aso_prov[i].id_asoc_prov;
                    nuevafila += "<tr class='rows_" + idNV + "'><td colspan='1'><center>" +
                        (i + 1) + "</center></td><td colspan='2'>● " +
                        list_aso_prov[i].proveedor + "</td><td colspan='2'><center> " +
                        list_aso_prov[i].institucion + "</td><td colspan='2'><center> " +
                        list_aso_prov[i].tipo_cta + "</td><td colspan='2'><center> " +
                        list_aso_prov[i].nCedula + "</td><td colspan='2'><center> " +
                        list_aso_prov[i].personaCuenta + "</td><td colspan='2'><center> " +
                        list_aso_prov[i].ncuenta + "</td><td colspan='2'><center> " +
                        list_aso_prov[i].valo_pago + "</center></td></tr>";
                }

                string tbody = "<tbody>" + nuevafila + "</tbody>";

                string _tablaFinal = "<table class='table' width='80%' border='1'cellspacing='0' cellpadding='0' style='margin: 0 auto;'>" +
             "<thead>" +
                "<tr>" +
                 "<th colspan='14'><center><img src='../Content/media/logos/espam.jpg' width='50%' height='70%'></center></th> " +
                "</tr> " +
                "<tr>" +
                  "<th colspan='14'><h2><center><br/>LISTADO DE CUENTA PROVEEDORES<br/></center></h2>" +
                  "<h4><center><br/>Pago de Proveedores a través de Transferencias<br/></center></h4></th>" +
                "</tr> " +
                "<tr>" +
                  "<th colspan='3' style='background-color:#f7f5f5'><center><b><br/>Fecha Actual: <br/></b></center></th>" +
                  "<td colspan='4'><center><br/>" + DateTime.Now.ToShortDateString() + "<br/></center></td>" +
                  "<th colspan='3' style='background-color:#f7f5f5'><center><b><br/>ASOCIACIÓN: <br/></b></center></th>" +
                  "<td colspan='4'><center><br/>" + _objAso.descripcion.ToUpper() + "<br/></center></td>" +
                 "</tr>" +
                "<tr>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/> Item <br/></b></center></th>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><b><br/>PROVEEEDOR <br/></b></th>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><center><b><br/>Institución<br/></b></center></th>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><center><b><br/>Tipo de cueta<br/></b></center></th>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><center><b><br/>Cédula<br/></b></center></th>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><center><b><br/>Nombres y Apellidos<br/></b></center></th>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><center><b><br/>N° Cuenta<br/></b></center></th>" +
                  "<th colspan='2' style='background-color:#f7f5f5'><center><b><br/>Valor a Pagar<br/></b></center></th>" +

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

        public ActionResult ConsultarConvenioR(string _idAsoProv)
        {
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                int _idAsoProvEntero = Convert.ToInt32(_idAsoProv);
                var _objConv = clsprov.mostrarConvenio(_idAsoProvEntero);
                string aso = ""; string prs = "";
                if (_objConv.aso == "AETPAM"){
                    aso += "ASOCIACIÓN DE EMPLEADOS Y TRABAJADORES DE LA ESCUELA SUPERIOR POLITÉCNICA AGROPECURIA DE MANABÍ “MANUEL FÉLIX LÓPEZ”";
                    prs += "Ing. Fabián Álava Rade";
                }else{
                    aso += "ASOCIACIÓN DE PROFESORES DE LA ESCUELA SUPERIOR POLITÉCNICA AGROPECURIA DE MANABÍ “MANUEL FÉLIX LÓPEZ”";
                    prs += "Ing. Gabriel Navarrete";
                }

                string _tablaFinal = "<table class='table' width='80%' cellspacing='0' cellpadding='0' style='margin: 0 auto;'>" +
             "<thead>" +
                "<tr>" +
                  "<th colspan='5'><h1><center><br/>C  O  N  V  E  N  I  O  <br/></center></h1></th>" +
                "</tr> " +
                "<tr>" +
                  "<td colspan='1'></td>" +
                  "<td colspan='3' style='text-align: justify;'><h4><br/>" +

                  " En la ciudad de Calceta, a día " + _objConv.fecha.ToString("MMMM dd, yyyy") +
                  " comparecen a la celebración del presente convenio, por una parte el " + prs +
                  " en su calidad de Presidente de la <b>" + aso +" - "+_objConv.aso+ " MFL</b>, por otra parte el/la Sr/Sra " + _objConv.persona_juridica+
                  " en calidad de propietario/a de <b>" + _objConv.nombre + "</b>, con RUC: <b>" + _objConv.RUC+ "</b>, quienes libre y voluntariamente," +
                  " conciertan a celebrar el presente convenio al tenor de las siguientes cláusulas:" +
                  "<br/><br/><b>PRIMERA.- " + _objConv.nombre + ",</b> ofrece servicio de " + _objConv.descripcion + ", a los miembros de la  " + aso + "." +
                  "<br/><br/><b>SEGUNDA.- " + _objConv.nombre + ",</b> se compromete en brindarle un crédito mensual, a los señores socios de la " + aso + "." +
                  "<br/><br/><b>TERCERA.-</b> El día quince  de cada mes,<b> " + _objConv.nombre + "</b>, presentará el cuadro de descuento, en la que constará el valor a descontarse del rol individual del socio de la "+_objConv.aso+ " MFL, si no ha sido recibido el quince de cada mes, este se hará el mes siguiente." +
                  "<br/><br/><b>CUARTA.-</b> Del precio de cada uno de los artículos <b> " + _objConv.nombre + "</b>, reconocerá el <b> " + _objConv.porcCom + " %</b> a beneficio de la " + _objConv.aso + " MFL." +
                  "<br/><br/><b>QUINTA.-</b> La " + _objConv.aso + " MFL, en los quince primeros días del mes siguiente, procederá a cancelar el valor descontado mediante rol de pago, correspondiente a cada socio, a <b> " + _objConv.nombre + "</b>." +
                  "<br/><br/><b>SEXTA.-</b> Toda divergencia que requiere fallo judicial, será debidamente tramitado en juicio verbal sumario,  y para el efecto las partes se someterán a los jueces de la ciudad de Calceta." +
                  "<br/><br/><b>SEPTIMA.-</b> El presente convenio tendrá  vigencia por el tiempo de doce meses, contados a partir de la fecha de la suscripción del mismo y se renovará automáticamente por igual plazo, a menos que una de las partes expresaren por escrito  y con treinta días de anticipación su voluntad de dar por terminado el mismo." +
                  "<br/><br/>Para su constancia y fiel cumplimiento las partes contratantes  lo suscriben por triplicado, en la ciudad de Calceta, a día " + _objConv.fecha.ToString("MMMM dd, yyyy") +"."+
                  "</h4></td>" +
                  "<td colspan='1'></td>" +
                 "</tr>" +
                 "<tr>" +
                   "<th colspan='4'></th>" +
                "</tr> " +
                "<tr>" +
                   "<th colspan='4'><br/><br/><br/></th>" +
                "</tr> " +
                "<tr>" +
                  "<td colspan='1'></td>" +
                  "<td colspan='1' style='background-color:#f7f5f5'><center><b> ________________<br/></b></center></th>" +
                  "<td colspan='1' style='background-color:#f7f5f5'><center><b> ________________<br/></b></center></th>" +
                  "<td colspan='1'></td>" +
                "</tr>" +
                "<tr>" +
                  "<td colspan='1'></td>" +
                  "<td colspan='1' style='background-color:#f7f5f5'><center><b> "+prs+" <br/></b></center></th>" +
                  "<td colspan='1' style='background-color:#f7f5f5'><center><b> " + _objConv.persona_juridica + "<br/></b></center></th>" +
                  "<td colspan='1'></td>" +
                "</tr>" +
                "<tr>" +
                  "<td colspan='1'></td>" +
                  "<td colspan='1'><center> PRESIDENTE - "+ _objConv.aso + " MFL.</center></th>" +
                  "<td colspan='1'><center> RUC:" + _objConv.RUC + "</center></th>" +
                  "<td colspan='1'></td>" +
                "</tr>" +
                "<tr>" +
                  "<td colspan='1'></td>" +
                  "<td colspan='1'><center><b> </b></center></th>" +
                  "<td colspan='1'><center><b> " + _objConv.nombre + "</b></center></th>" +
                  "<td colspan='1'></td>" +
                "</tr>" +
              "</thead>" +
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
