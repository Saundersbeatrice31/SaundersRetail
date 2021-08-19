using Microsoft.AspNet.Identity;
using SaundersRetail.Models.Inventory;
using SaundersRetail.Models.InventorySale;
using SaundersRetail.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaundersRetail.WebMVC.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            
            var service = new InventoryService();
            var model = service.GetInventories();
            return View(model);
        }
        private InventoryService CreateInventoryService()
        {           
            var service = new InventoryService();
            return service;
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateInventoryService();
            var model = svc.GetInventoryById(id);
            return View(model);
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InventoryCreate model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                var service = CreateInventoryService();
                if (service.CreateInventory(model))
                {
                    TempData["SaveResult"] = "Your Inventory was created.";
                    return RedirectToAction("Index");
                };
                ModelState.AddModelError("", "The inventory could not be created.");
                return View(model);

            }
            catch
            {
                return View(model);
            }
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateInventoryService();
            var detail = service.GetInventoryById(id);
            var model =
                new InventoryEdit
                {
                    ProductID = detail.ProductID,
                    Quantity = detail.Quantity,
                    ProductName = detail.ProductName,
                    
                };
            return View(model);
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, InventoryEdit model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                if (model.ProductID != id)
                {
                    ModelState.AddModelError("", "id Mismatch");
                    return View(model);
                }

                var service = CreateInventoryService();
                if (service.UpdateInventory(model))
                {
                    TempData["SaveResult"] = "Your inventory item was Updated.";
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Your Inventory item could not be updated");
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Inventory/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateInventoryService();
            var model = service.GetInventoryById(id);
            return View(model);
        }
        public ActionResult AddSaleToInventory(int id)
        {
            var model = new InventorySaleCreate()
            {
                SaleID = id

            };
            return View(model);
        }
        [HttpPost]
        public ActionResult AddSaleToInventory(int id, InventorySaleCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            if (model.SaleID != id)
            {
                ModelState.AddModelError("", "id Mismatch");
                return View(model);
            }
            var service = CreateInventoryService();
            if (service.CreateInventorySale(model))
            {
                TempData["SaveResult"] = "Your product was added.";
                return RedirectToAction("Index");
            }
            return View(model);

        }


        // POST: Inventory/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, InventoryDetail model)
        {
            try
            {
                var service = CreateInventoryService();
                service.DeleteInventory(id);
                TempData["SaveResult"] = "Your Inventory item was deleted";

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}
