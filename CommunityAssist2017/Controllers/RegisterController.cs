using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommunityAssist2017.Models;

namespace CommunityAssist2017.Controllers
{
    public class RegisterController : Controller
    {
        CommunityAssist2017Entities db = new CommunityAssist2017Entities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Lastname, Firstname, Email, Phone, Plainpassword, Apartment, Street, City, State, Zipcode")]NewPerson np)
        {
            Message m = new Message();
            int result = db.usp_Register(np.LastName, np.FirstName, np.Email, np.Phone, np.PlainPassword, np.Apartment, np.Street, np.City, np.State, np.Zipcode);
            
            if(result != -1)
            {
                m.MessageText = "Welcome," + np.FirstName;
            }
            else
            {
                m.MessageText = "Sorry, but something seems to have gone wrong with the registration.";
            }
            return View("Result", m);
        }
        public ActionResult Result(Message m)
        {
            return View(m);
        }
    }
}