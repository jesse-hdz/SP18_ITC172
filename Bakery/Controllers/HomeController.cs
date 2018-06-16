using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakery.Models;


namespace Bakery.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Boricua Bakery";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Selling the Best of the Puerto Rican Baked Goods.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Us";

            return View();
        }
    }
}