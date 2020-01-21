using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Creditos.Clases;
using Creditos.Models;

namespace Creditos.Controllers{
    public class mesController : Controller{
        // GET: mes
        public ActionResult Index(){
            ViewBag.Message = "Your application description page.";
            List<mMes> mes = new List<mMes>();
            clsMes clsmes = new clsMes();
            mes = clsmes.mostrarMeses();
            return View(mes);
        }

        // GET: mes/Details/5
        public ActionResult Details(int id){
            return View();
        }

        // GET: mes/Create
        public ActionResult Create(){
            return View();
        }

        // POST: mes/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection){
            try{
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch{
                return View();
            }
        }

        // GET: mes/Edit/5
        public ActionResult Edit(int id){
            return View();
        }

        // POST: mes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection){
            try{
                // TODO: Add update logic here
                return RedirectToAction("Index");
            }
            catch{
                return View();
            }
        }

        // GET: mes/Delete/5
        public ActionResult Delete(int id){
            return View();
        }

        // POST: mes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection){
            try{
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch{
                return View();
            }
        }
    }
}
