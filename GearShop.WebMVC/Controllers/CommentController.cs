using GearShop.Models.Comment_Models;
using GearShop.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GearShop.WebMVC.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            var service = CreateCommentService();
            var model = service.GetComments();
            return View(model);
        }

        // GET: Comment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CommentCreate model)
        {
            model.GearId = Convert.ToInt32(TempData["GearIdForComment"]);

            if (!ModelState.IsValid) return View(model);

            var service = CreateCommentService();

            if (service.CreateComment(model))
            {
                TempData["SaveResult"] = "Your Comment was added!";
                return RedirectToAction("Index", "Category");
            }

            ModelState.AddModelError("", "Comment was not created successfully.");

            return View(model);
        }

        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            return service;
        }
    }
}