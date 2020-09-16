using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Creditos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult index()
        {
            return View();
            //Leer la variable de sesion de la aplicacion principal
            //Comprobar que no == null
            //funcion if () para determinar la sesion activa
            //comparar los roles.

            //Si la variable es "empleado,docente" redirect --> Layout_User
            //agregar variables de sesion para la app
            //id_asociacion, ---

            //Si la variable es "proveedor" redirect --> Layout_Prov
            //agregar variables de sesion para la app

            //Si la variable es "Nomina" redirect --> Layout_Nomina
            //agregar variables de sesion para la app

            //Si la variable es "Asoc" redirect --> Layout_Aso
            //agregar variables de sesion para la app



        }

        public ActionResult about()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}