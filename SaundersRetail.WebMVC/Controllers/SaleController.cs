using Microsoft.AspNet.Identity;
using SaundersRetail.Models.ProductSale;
using SaundersRetail.Models.Sale;
using SaundersRetail.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaundersRetail.WebMVC.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        // GET: Sale
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SaleService(userId);
            var model = service.GetSales();
            return View(model);

           
        }

        // GET: Sale/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateSaleService();
            var model = svc.GetSaleById(id);
            return View(model);
            
        }

        // GET: Sale/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sale/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaleCreate model)
        {
            try
            {
                // TODO: Add insert logic here

                if (!ModelState.IsValid) return View(model);

                var service = CreateSaleService();
                if (service.CreateSale(model))
                {
                    TempData["SaveResult"] = "Your Sale was created.";
                    return RedirectToAction("AddProductToSale", new { id = model.SaleID });
                };
                ModelState.AddModelError("", "The Sale could not be created.");
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }
        private SaleService CreateSaleService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SaleService(userId);
            return service;
        }

        // GET: Sale/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateSaleService();
            var detail = service.GetSaleById(id);
            var model =
                new SaleEdit
                { 
                    SaleID = detail.SaleID,
                    SubTotal = detail.SubTotal,
                    Tax = detail.Tax,
                    Total = detail.Total
                };
            return View(model);
        }

        // POST: Sale/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SaleEdit model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                if (model.SaleID != id)
                {
                    ModelState.AddModelError("", "id Mismatch");
                    return View(model);
                }

                var service = CreateSaleService();
                if (service.UpdateSale(model))
                {
                    TempData["SaveResult"] = "Your Sale was Updated.";
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Your Sale could not be updated");
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }
        public ActionResult AddProductToSale (int id)
        {
            var model = new ProductSaleCreate()
           
            {                  
                SaleID = id                
            };
            ViewBag.ProductNameSelectList = new SelectList(ProductDropDown(), "ID", "ProductName");            
            return View(model);            
        }
        private  List<ProductSaleCreate> ProductDropDown()
        {
            var productNames = new List<ProductSaleCreate>();
            productNames.Add(new ProductSaleCreate() { ID = 1, ProductName = "Shirts" });
            productNames.Add(new ProductSaleCreate() { ID = 2, ProductName = "Shoes" });
            productNames.Add(new ProductSaleCreate() { ID = 3, ProductName = "Purses" });
            productNames.Add(new ProductSaleCreate() { ID = 4, ProductName = "Pants" });
            productNames.Add(new ProductSaleCreate() { ID = 5, ProductName = "Shirts" });

            return productNames;
        }
        [HttpPost]
        public ActionResult AddProductToSale(int id, ProductSaleCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.ID != id)
            {
                ModelState.AddModelError("", "id Mismatch");
                return View(model);
            }
            var service = CreateSaleService();
            if (service.CreateProductSale(model))
            {
                TempData["SaveResult"] = "Your product was added.";
                return RedirectToAction("Index");                
            }
            return View(model);

        }


        // GET: Sale/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateSaleService();
            var model = service.GetSaleById(id);
            return View(model);
        }

        // POST: Sale/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SaleDetail model )
        {           
                // TODO: Add delete logic here
                var service = CreateSaleService();
                service.DeleteSale(id);
                TempData["SaveResult"] = "Your Sale was deleted";

                return RedirectToAction("Index");                                      
        }
    }
}
