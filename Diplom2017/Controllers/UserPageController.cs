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
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password))
            {
                ModelState.AddModelError("Error", "Wrong name or password");
            }
            else
            {
                // If user exist then return his page
                return View("User");
            }
            return View();
        }
        public ActionResult User()
        {
            return View();
        }
        public void Online(string name)
        {
           
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"F:\Git\LessonManagement\Diplom2017\Content\Online\WriteText.txt", true))
            {
                file.WriteLine(name);
            }
        }

    }
}