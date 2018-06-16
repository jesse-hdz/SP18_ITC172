using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakery.Models;

namespace Bakery.Controllers
{
    public class LogInController : Controller
    {
        BakeryEntities db = new BakeryEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include="Email, Password")]LoginClass lc)
        {
            int results = db.usp_Login(lc.Email, lc.Password);
            int vk = 0;
            Message msg = new Message();
            if (results != -1)   
            {
                var pk = (from r in db.People where r.PersonEmail.Equals(lc.Email) select r.PersonKey).FirstOrDefault();
                vk = (int)pk;
                Session["PersonKey"] = vk;
                msg.MessageText = "Welcome, " + lc.Email;

                        
            }
            else
            {
                msg.MessageText="Invalid Login";
            }
            return View("result", msg);
        }
        public ActionResult Result(Message msg)
        {
            return View(msg);
        }
    }
}