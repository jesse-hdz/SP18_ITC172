using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2017.Models;

namespace CommunityAssist2017.Controllers
{
    public class DonationController : Controller
    {
        // GET: Donation
        public ActionResult Index()
        {
            if (Session["PersonKey"] == null)
            {
                //Message m = new Message ("You must Login to Donate");
                return RedirectToAction("Index", "Login"); //this will redirect the user to the login page if they did not log in
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Personkey, DonationDate, DonationAmount, DonationConfirmationCode")]Donation d)

        {
            CommunityAssist2017Entities db = new CommunityAssist2017Entities();
            d.DonationConfirmationCode = Guid.NewGuid();
            d.PersonKey=(int)Session["PersonKey"];
            d.DonationDate=DateTime.Now;
            ConfirmationCode=d.DonationConfirmationCode;
            db.Donations.Add(d);
            db.SaveChanges();
            Message m = new Message("Thank you for your donations!" + ConfirmationCode);
            return View("Result", m);
    }

    public ActionResult Result(Message msg)
    {
        return View(msg);
    }

}
    }