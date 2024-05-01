using blood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace blood.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (model.Username == "abc" && model.Password == "123")
            {
                // Successful login
                return RedirectToAction("Index", "Donors");
            }
            else
            {
                // Invalid credentials, return to login page with error message
                ModelState.AddModelError("", "Invalid username or password.");
                return View(model);
            }
        }
    }
}