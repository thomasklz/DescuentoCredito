using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Creditos.Clases;
using Creditos.Models;

namespace Creditos.Controllers
{
    public class asociacionController : Controller
    {
        // GET: asociacion
        public ActionResult Index(){
             ViewBag.Message = "Your application description page.";
             List<mAsociacion> aso = new List<mAsociacion>();
             clsAsociacion clsasoc = new clsAsociacion();
             aso = clsasoc.mostrar();
             return View(aso);
        }

        // GET: asociacion/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: asociacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: asociacion/Create
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

        // GET: asociacion/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: asociacion/Edit/5
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

        // GET: asociacion/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: asociacion/Delete/5
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
