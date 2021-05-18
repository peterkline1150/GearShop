using GearShop.Models;
using GearShop.Models.Gear_Models;
using GearShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GearShop.WebMVC.Controllers
{
    public class GearController : Controller
    {
        GearService service = new GearService();

        // GET: Gear/Index
        public ActionResult Index()
        {
            var model = service.GetGear();
            return View(model);
        }

        // GET: Gear/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gear/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GearCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (service.CreateGear(model))
            {
                TempData["SaveResults"] = "Gear Created Successfully!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Could not create Gear.");
            return View(model);
        }

        // GET: Gear/Details/{id}
        public ActionResult Details(int id)
        {
            var model = service.GetGearById(id);
            TempData["GearIdForComment"] = model.GearId;
            return View(model);
        }

        // POST: Gear/Details/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int id, GearDetail model)
        {
            if (!ModelState.IsValid) return View(model);

            if (id != model.GearId)
            {
                ModelState.AddModelError("", "IDs do not match");
                return View(model);
            }

            if (model.NumberOfGearInCart <= 0 || model.NumberOfGearInCart > model.NumAvailable)
            {
                ModelState.AddModelError("", "You cannot purchase that many");
                return View(model);
            }

            TempData["GearToAddToCart"] = model;

            return RedirectToAction("AddGearToCart", "Cart");
        }

        // GET: Gear/Edit/{id}
        public ActionResult Edit(int id)
        {
            var detail = service.GetGearById(id);
            var model = new GearEdit()
            {
                GearId = detail.GearId,
                Name = detail.Name,
                Price = detail.Price,
                NumAvailable = detail.NumAvailable,
                CategoryId = detail.Category.CategoryId
            };

            return View(model);
        }

        // POST: Gear/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GearEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (id != model.GearId)
            {
                ModelState.AddModelError("", "IDs do not match.");
                return View(model);
            }

            if (service.UpdateGear(model))
            {
                TempData["SaveResult"] = "Gear Updated Successfully!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Gear was not able to update.");
            return View(model);
        }

        // GET: Gear/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = service.GetGearById(id);
            return View(model);
        }

        // POST: Gear/Delete/{id}
        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGear(int id)
        {
            service.DeleteGear(id);

            TempData["SaveResult"] = "Gear Deleted.";

            return RedirectToAction("Index");
        }

        

    }
}