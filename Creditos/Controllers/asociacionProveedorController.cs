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
        public ActionResult ConsultarAsoProvR(){
            string _mensaje = "<div class='alert alert-danger text-center' role='alert'>OCURRIÓ UN ERROR INESPERADO</div>";
            bool _validar = false;
            try
            {
                list_aso_prov = cls_aso_pro.mostrarRpt(1);
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
                 "<th colspan='4'><center><img src='../Content/media/logos/espam.png' width='80%' height='120%'></center></th> " +
                "</tr> " +
                "<tr>" +
                  "<th colspan='4'><h2><center><br/>LISTADO DE PROVEEDORES ASOCIADOS<br/></center></h2></th>" +
                "</tr> " +
                "<tr>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>Fecha Actual<br/></b></center></th>" +
                  "<td colspan='1'><center><br/>" + DateTime.Now.ToShortDateString() + "<br/></center></td>" +
                  "<th colspan='1' style='background-color:#f7f5f5'><center><b><br/>ASOCIACIÓN<br/></b></center></th>" +
                  "<td colspan='1'><center><br/>AETPAM<br/></center></td>" +
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
    }
}
