using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaundersRetail.WebMVC.Controllers
{
    public class SaleDetailController : Controller
    {
        // GET: SaleDetail
        public ActionResult Index()
        {
            return View();
        }

        // GET: SaleDetail/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SaleDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleDetail/Create
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

        // GET: SaleDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SaleDetail/Edit/5
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

        // GET: SaleDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SaleDetail/Delete/5
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
