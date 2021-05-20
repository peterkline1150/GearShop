using GearShop.Models.Reply_Models;
using GearShop.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GearShop.WebMVC.Controllers
{
    public class ReplyController : Controller
    {
        // GET: Reply/Index
        public ActionResult Index()
        {
            var service = CreateReplyService();
            var model = service.GetReplies();
            return View(model);
        }

        // GET: Reply/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reply/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReplyCreate model)
        {
            model.CommentId = Convert.ToInt32(TempData["CommentId"]);

            if (!ModelState.IsValid) return View(model);

            var service = CreateReplyService();

            if (service.CreateReply(model))
            {
                TempData["SaveResult"] = "Reply was created!";
                return RedirectToAction("Details", "Comment", new { id = model.CommentId });
            }

            ModelState.AddModelError("", "Reply was not created.");
            return View(model);
        }

        // GET: Reply/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateReplyService();
            var detail = service.GetReplyById(id);
            var model = new ReplyEdit()
            {
                ReplyId = detail.ReplyId,
                ReplyText = detail.ReplyText
            };

            return View(model);
        }

        // POST: Reply/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReplyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ReplyId != id)
            {
                ModelState.AddModelError("", "IDs do not match.");
                return View(model);
            }

            var service = CreateReplyService();

            if (service.UpdateReply(model))
            {
                TempData["SaveResult"] = "Reply successfully updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Reply was not updated");
            return View(model);
        }

        // GET: Reply/Delete/{id}
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateReplyService();
            var model = service.GetReplyById(id);
            return View(model);
        }

        // POST: Reply/Delete/{id}
        [ActionName("Delete")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReply(int id)
        {
            var service = CreateReplyService();
            service.DeleteReply(id);

            TempData["SaveResult"] = "Reply was deleted successfully.";

            return RedirectToAction("Index");


        }

        private ReplyService CreateReplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ReplyService(userId);
            return service;
        }
    }
}