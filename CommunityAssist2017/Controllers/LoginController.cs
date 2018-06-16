using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2017.Models;

namespace CommunityAssist2017.Controllers
{
    public class LoginController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
      
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Email, PlainPassword")]LoginClass lc)
        {
            int results = db.usp_Login(lc.Email, lc.PlainPassword);
            int personkey = 0;
            Message msg = new Message();
            if(results != -1)
            {
                var pk = (from r in db.People where r.PersonEmail.Equals(lc.Email) select r.PersonKey).FirstOrDefault();
                personkey = (int)pk;
                Session["PersonKey"] = personkey;

                msg.MessageText = "Welcome, " + lc.Email;
            }
            else
            {
                msg.MessageText = "Invalid Login. Please try again.";
            }
            return View("Result", msg);
        }
        public ActionResult Reuslt(Message msg)
        {
            return View(msg);
        }
    }
}