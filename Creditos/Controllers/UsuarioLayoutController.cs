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
    public class UsuarioLayoutController : Controller{

        // Required: ingresos
        BD_Roles_Creditos_Entities db = new BD_Roles_Creditos_Entities();
        clsMes clsmes = new clsMes();
        clsAsociacion clsAso = new clsAsociacion();
        clsCredito clscred = new clsCredito();
        clsIngresos clsingreso = new clsIngresos();
        clsTipoIngreso clstipoingresos = new clsTipoIngreso();
        List<mIngresos> list_ingreso = new List<mIngresos>();
        clsEmpleadoAsociacion empl_aso = new clsEmpleadoAsociacion();
        // Fin: ingresos

        public ActionResult Layout_User()
        {
            return View();
        }
    }
}
