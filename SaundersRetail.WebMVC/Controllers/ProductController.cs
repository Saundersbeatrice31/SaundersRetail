using Microsoft.AspNet.Identity;
using SaundersRetail.Models.Product;
using SaundersRetail.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaundersRetail.WebMVC.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {          
            var service = new ProductService();
            var model = service.GetProducts();
            return View(model);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateProductService();
            var model = svc.GetProductById(id);
            return View(model);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductCreate model)
        {
            try
            {
                // TODO: Add insert logic here
                if (!ModelState.IsValid) return View(model);

                var service = CreateProductService();
                if (service.CreateProduct(model))
                {
                    TempData["SaveResult"] = "Your product was created.";
                    return RedirectToAction("Index");
                };
                ModelState.AddModelError("", "The product could not be added.");
                return View(model);


            }
            catch
            {
                return View(model);
            }
        }
        private ProductService CreateProductService()
        {
            
            var service = new ProductService();
            return service;
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateProductService();
            var detail = service.GetProductById(id);
            var model =
                new ProductEdit
                {
                    ID = detail.ID,
                    ProductName = detail.ProductName,
                    Description = detail.Description,
                    RetailPrice = detail.RetailPrice,
                    CreatedDate= detail.CreatedDate,
                    LastModified = detail.LastModified
                };
            return View(model);
            
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ProductEdit model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                if (model.ID != id)
                {
                    ModelState.AddModelError("", "id Mismatch");
                    return View(model);
                }

                var service = CreateProductService();
                if (service.UpdateProduct(model))
                {
                    TempData["SaveResult"] = "Your product was Updated.";
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Your Product could not be updated");
                return View(model);

            }
            catch
            {
                return View(model);
            }
        }

        // GET: Product/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateProductService();
            var model = service.GetProductById(id);
            return View(model);
        }

        // POST: Product/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductDetail model)
        {
            try
            {
                var service = CreateProductService();
                service.DeleteProduct(id);
                TempData["SaveResult"] = "Your Product was deleted";

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}
