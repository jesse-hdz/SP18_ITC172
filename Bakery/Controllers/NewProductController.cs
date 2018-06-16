using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakery.Models;

namespace Bakery.Controllers
{

    public class NewProductController : Controller
    {
        BakeryEntities db = new BakeryEntities();
        
        public ActionResult Index()
        {
            if (Session["PersonKey"] == null)
            {
                Message msg = new Message();
                msg.MessageText = "You must be logged in as an employee to add Products. Please Log In.";
                return RedirectToAction("Result", msg);
            }
            if (Session["PersonKey"] != null)
            {
        
                int key = (int)Session["PersonKey"];
                var emp = (from e in db.Employees where e.PersonKey == key select e.PersonKey).FirstOrDefault();
                if (emp == null)
                {
                    Message msg = new Message();
                    msg.MessageText = "You must be logged in as an employee to add Products. Please Log In.";
                    return RedirectToAction("Result", msg);
                }
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "ProductName, ProductPrice")]Product p)
        {
            db.Products.Add(p);
            db.SaveChanges();
            Message msg = new Message();
            msg.MessageText = p.ProductName + " was added.";
            return View("Result", msg);
        }

        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}