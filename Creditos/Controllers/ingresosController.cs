using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Creditos.Clases;
using Creditos.Models;

namespace Creditos.Controllers
{
    public class ingresosController : Controller
    {
        // GET: ingresos
        public ActionResult Index(){
            ViewBag.Message = "Your application description page.";
            //xxModel model = new xxModel();

            List<mTipoIngreso> tp_ingr = new List<mTipoIngreso>();
            //List<mMes> mes = new List<mMes>();
            //List<mAsociacion> asoc = new List<mAsociacion>();

            clsTipoIngreso clst_ingr = new clsTipoIngreso();
            //clsMes clsmes = new clsMes();
            //clsAsociacion clsasoc = new clsAsociacion();

            tp_ingr = clst_ingr.mostrar();
            //mes = clsmes.mostrarMeses();
            //asoc = clsasoc.mostrar();

            //model.List1 = mes;
            //model.List2 = tp_ingr;
            //model.List3 = asoc;

            return View(tp_ingr);
        }

        // GET: ingresos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ingresos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ingresos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ingresos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ingresos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ingresos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ingresos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
