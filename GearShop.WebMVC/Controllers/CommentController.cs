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

        // GET: Comment/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateCommentService();
            var model = service.GetCommentById(id);
            TempData["CommentToReplyTo"] = model;
            TempData["CommentId"] = model.CommentId;
            return View(model);
        }

        // GET: Comment/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateCommentService();
            var detail = service.GetCommentById(id);
            var model = new CommentEdit()
            {
                CommentId = detail.CommentId,
                CommentText = detail.CommentText,
                CommentTitle = detail.CommentTitle,
                Rating = detail.Rating
            };

            return View(model);
        }

        // POST: Comment/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CommentEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (id != model.CommentId)
            {
                ModelState.AddModelError("", "IDs do not match.");
                return View(model);
            }

            var service = CreateCommentService();

            if (service.UpdateComment(model))
            {
                TempData["SaveResult"] = "Comment Edited.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Comment was not able to be edited.");
            return View(model);
        }

        // GET: Comment/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateCommentService();
            var model = service.GetCommentById(id);
            return View(model);
        }

        // POST: Comment/Delete/{id}
        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComment(int id)
        {
            var service = CreateCommentService();
            service.DeleteComment(id);
            return RedirectToAction("Index");
        }

        private CommentService CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CommentService(userId);
            return service;
        }
    }
}