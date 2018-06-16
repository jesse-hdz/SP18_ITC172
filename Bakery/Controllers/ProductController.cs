using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakery.Models;

namespace Bakery.Controllers
{
    public class ProductController : Controller
    {
        BakeryEntities db = new BakeryEntities();
        public ActionResult Product()
        {
            //List of Baked Goods
            return View(db.Products.ToList());
        }
    }
}