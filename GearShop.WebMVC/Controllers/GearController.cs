using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GearShop.WebMVC.Controllers
{
    public class GearController : Controller
    {
        // GET: Gear/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Gear/Create
        public ActionResult Create()
        {
            return View();
        }
    }
}