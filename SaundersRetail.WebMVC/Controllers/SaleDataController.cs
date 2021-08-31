using Microsoft.AspNet.Identity;
using SaundersRetail.Models.ProductSaleData;
using SaundersRetail.Models.SaleData;
using SaundersRetail.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaundersRetail.WebMVC.Controllers
{
    [Authorize(Roles ="Admin")]
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
                return RedirectToAction("AddProductToSaleData", new { id = model.SDID });
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
        public ActionResult AddProductToSaleData(int id)
        {
            var model = new ProductSaleDataCreate()

            {
                ID = id
            };
            ViewBag.ProductNameSelectList = new SelectList(ProductDropDown(), "ID", "ProductName");
            return View(model);
        }
        private List<ProductSaleDataCreate> ProductDropDown()
        {
            var productNames = new List<ProductSaleDataCreate>();
            productNames.Add(new ProductSaleDataCreate() { ID = 1, ProductName = "Shirts" });
            productNames.Add(new ProductSaleDataCreate() { ID = 2, ProductName = "Shoes" });
            productNames.Add(new ProductSaleDataCreate() { ID = 3, ProductName = "Purses" });
            productNames.Add(new ProductSaleDataCreate() { ID = 4, ProductName = "Pants" });
            productNames.Add(new ProductSaleDataCreate() { ID = 5, ProductName = "Shirts" });

            return productNames;
        }
        [HttpPost]
        public ActionResult AddProductToSale(int id, ProductSaleDataCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ID != id)
            {
                ModelState.AddModelError("", "id Mismatch");
                return View(model);
            }
            var service = CreateSaleDataService();
            if (service.CreateProductSaleData(model))
            {
                TempData["SaveResult"] = "Your product was added.";
                return RedirectToAction("Index");
            }
            return View(model);

        }
    }
}
