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
        public ActionResult Index()
        {
            return View();
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
