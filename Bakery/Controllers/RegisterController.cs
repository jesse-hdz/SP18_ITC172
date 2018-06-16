using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bakery.Models;

namespace Bakery.Controllers
{
    public class RegisterController : Controller
    {
        BakeryEntities db = new BakeryEntities();
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "PersonLastName, PersonFirstName, PersonEmail, PersonPhone, PersonPlainPassword")]NewPerson np)
        {
            Message m = new Message();
            int result = db.usp_NewPerson(np.PersonLastName, np.PersonFirstName, np.PersonEmail, np.PersonPhone, np.PersonPlainPassword);

            if (result != -1)
            {
                m.MessageText = "Welcome, " + np.PersonFirstName;

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