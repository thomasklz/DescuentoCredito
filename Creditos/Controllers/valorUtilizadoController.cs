using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Creditos.Clases;
using Creditos.Models;

namespace Creditos.Controllers
{
    public class valorUtilizadoController : Controller
    {
        // GET: valorUtilizado
        public ActionResult Index()
        {
            return View();
        }

        // GET: valorUtilizado/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: valorUtilizado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: valorUtilizado/Create
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

        // GET: valorUtilizado/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: valorUtilizado/Edit/5
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

        // GET: valorUtilizado/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: valorUtilizado/Delete/5
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
