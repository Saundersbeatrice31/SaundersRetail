using Microsoft.AspNet.Identity;
using SaundersRetail.Models.Cashier;
using SaundersRetail.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SaundersRetail.WebMVC.Controllers
{
    [Authorize]
    public class CashierController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var service = new CashierService();
            var model = service.GetCashiers();
            return View(model);
        }
        private CashierService CreateCashierService()
        {           
            var service = new CashierService();
            return service;
        }
        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var svc = CreateCashierService();
            var model = svc.GetCashierById(id);
            return View(model);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CashierCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCashierService();
            if (service.CreateCashier(model))
            {
                TempData["SaveResult"] = "Your Cashier was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "The cashier could not be created.");
            return View(model);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var service = CreateCashierService();
            var detail = service.GetCashierById(id);
            var model =
                new CashierEdit
                {
                    CashierID = detail.CashierID,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    EmailAddress = detail.EmailAddress
                };
            return View(model);

        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CashierEdit model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);
                if (model.CashierID != id)
                {
                    ModelState.AddModelError("", "id Mismatch");
                    return View(model);
                }

                var service = CreateCashierService();
                if (service.UpdateCashier(model))
                {
                    TempData["SaveResult"] = "Your Cashier was Updated.";
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Your Cashier could not be updated");
                return View(model);
            }
            catch
            {
                return View(model);
            }
        }

        // GET: User/Delete/5
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateCashierService();
            var model = service.GetCashierById(id);
            return View(model);

        }

        // POST: User/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CashierDetail model)
        {
            try
            {
                var service = CreateCashierService();
                service.DeleteCashier(id);
                TempData["SaveResult"] = "Your Cashier record was deleted";

                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }
    }
}
