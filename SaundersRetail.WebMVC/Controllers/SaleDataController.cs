using Microsoft.AspNet.Identity;
using SaundersRetail.Models.SaleData;
using SaundersRetail.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaundersRetail.WebMVC.Controllers
{
    [Authorize]
    public class SaleDataController : Controller
    {
        // GET: SaleData
        public ActionResult Index()
        {
           
            var service = new SaleDataService();
            var model = service.GetSaleData();
            return View(model);
        }
        private SaleDataService CreateSaleDataService()
        {
            
            var service = new SaleDataService();
            return service;
        }

        // GET: SaleDetail/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateSaleDataService();
            var model = svc.GetSaleDataById(id);
            return View(model);
        }

        // GET: SaleDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SaleDetail/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleDataCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSaleDataService();
            if (service.CreateSaleData(model))
            {
                TempData["SaveResult"] = "Your Sales Data was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "The Sale Data could not be created.");
            return View(model);

        }

        // GET: SaleDetail/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateSaleDataService();
            var detail = service.GetSaleDataById(id);
            var model =
                new SaleDataEdit
                {
                    ProductID = detail.ProductID,
                    Quantity = detail.Quantity,
                    PurchasePrice = detail.PurchasePrice,
                    PurchaseDate = detail.PurchaseDate
                };
            return View(model);

        }

        // POST: SaleDetail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SaleDataEdit model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.SDID != id)
            {
                ModelState.AddModelError("", "id Mismatch");
                return View(model);
            }

            var service = CreateSaleDataService();
            if (service.UpdateSaleData(model))
            {
                TempData["SaveResult"] = "Your Sales Data was Updated.";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Your Sales Data could not be updated");
            return View(model);

        }

        // GET: SaleDetail/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateSaleDataService();
            var model = service.GetSaleDataById(id);
            return View(model);
        }

        // POST: SaleDetail/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SaleDataDetail model)
        {
            try
            {
                var service = CreateSaleDataService();
                service.DeleteSaleData(id);
                TempData["SaveResult"] = "Your Sales Data was deleted";

                return RedirectToAction("Index");

            }
            catch
            {
                return View(model);
            }
        }
    }
}
