using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Diplom2017.Controllers
{
    public class UserPageController : Controller
    {
        // GET: UserPage

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string password)
        {
            if (string.IsNullOrEmpty(name))
            {
                ModelState.AddModelError("Error", "Wrong name or password");
            }
            else
            {
               
                return View("User");
            }
            return View();
        }

        public ActionResult User()
        {
            return View();
        }

    }
}