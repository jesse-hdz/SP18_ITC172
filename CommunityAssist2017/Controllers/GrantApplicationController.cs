using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2017.Models;

namespace CommunityAssist2017.Controllers
{
    public class GrantApplicationController : Controller
    {
        // GET: GrantApplication
        CommunityAssist2017Entities db = new CommunityAssist2017Entities ();
        public ActionResult Index()
        {
            if (Session["PersonKey"] == null)
            {
                Message msg = new Message();
                msg.MessageText = "You must be logged in to apply for a grant. Please Log In";
                return RedirectToAction("Result", msg);
            }
            ViewBag.GrantList = new SelectList(db.GrantTypes, "GrantTypeKey", "GrantTypeName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "PersonKey, GrantTypeKey, GrantApplicationDate, GrantApplicationReason, GrantApplicationRequestedAmount, GrantApplicationStatusKey")]GrantApplication ga)

        {
            try
            {

                ga.PersonKey = (int)Session["PersonKey"];
                ga.GrantAppicationDate = DateTime.Now;
                ga.GrantApplicationStatusKey = 1;
                db.SaveChanges();
                Message m = new Message("Thank you. We have recieved your application.");
                return RedirectToAction("Result", m);
            }
            catch(Exception e)
            {
                Message m = new Message();
                    m.MessageText = e.Message;
                return RedirectToAction("Result", m);
            }
        }
        public ActionResult Result(Message msg)
        {
            return View(msg);
        }
    }
}