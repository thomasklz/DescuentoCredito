using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Creditos.Clases;
using Creditos.Models;

namespace Creditos.Controllers
{
    public class subdescuentoController : Controller
    {
        // GET: subdescuento
        public ActionResult Index()
        {
            return View();
        }

        // GET: subdescuento/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: subdescuento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: subdescuento/Create
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

        // GET: subdescuento/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: subdescuento/Edit/5
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

        // GET: subdescuento/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: subdescuento/Delete/5
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
