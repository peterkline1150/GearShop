using GearShop.Models.Category_Models;
using GearShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GearShop.WebMVC.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService service = new CategoryService();

        // GET: Category/Index
        public ActionResult Index()
        {
            var model = service.GetCategories();
            return View(model);
        }

        // GET: Category/IndexByCategoryType
        public ActionResult IndexByCategoryType(GearShop.Data.CategoryType categoryType)
        {
            var model = service.GetCategoriesByCategoryType(categoryType);
            return View(model);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (service.CreateCategory(model))
            {
                TempData["SaveResult"] = "Category Created!";

                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Category could not be added.");

            return View(model);
        }

        // GET: Category/Details/{id}
        public ActionResult Details(int id)
        {
            var model = service.GetCategoryById(id);

            return View(model);
        }

        // GET: Category/Edit/{id}
        public ActionResult Edit(int id)
        {
            var detail = service.GetCategoryById(id);

            var model = new CategoryEdit()
            {
                CategoryId = detail.CategoryId,
                CategoryName = detail.CategoryName,
                CategoryType = detail.CategoryType
            };
            return View(model);
        }

        // POST: Category/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CategoryEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CategoryId != id)
            {
                ModelState.AddModelError("", "IDs do not match.");
                return View(model);
            }

            if (service.UpdateCategory(model))
            {
                TempData["SaveResult"] = "Category Updated!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Category could not be updated.");
            return View(model);
        }

        // GET: Category/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var model = service.GetCategoryById(id);

            return View(model);
        }

        // POST: Category/Delete/{id}
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCategory(int id)
        {
            service.DeleteCategory(id);

            TempData["SaveResult"] = "Category Deleted!";

            return RedirectToAction("Index");
        }
    }
}