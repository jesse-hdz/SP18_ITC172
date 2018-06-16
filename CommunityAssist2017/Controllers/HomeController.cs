using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2017.Models;


namespace CommunityAssist2017.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            return View(db.GrantTypes.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Community Assist description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Community Assist contact page.";

            return View();
        }
    }
}