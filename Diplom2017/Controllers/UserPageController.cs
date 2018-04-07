using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Diplom2017.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Diplom2017.App_Data;
using System.Data;

namespace Diplom2017
{

    public class UserPageController : Controller
    {
        // GET: UserPage

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
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


        [HttpPost]
        public void Answers(string radio)
        {

            string userName = "Arman Amrazyan";

            string htmlTags = string.Empty;

            int userAnswer = Convert.ToInt32(radio); // change

            int rightAnswer = 1;

            List<UserAnswers> userAnswers;

            List<UserAnswers> AllUsersAndAnswers = new List<UserAnswers>();

            AllUsersAndAnswers.Add(new UserAnswers() { UserName = "Arman Amrazyan", Answer = 1 });
            AllUsersAndAnswers.Add(new UserAnswers() { UserName = "Hayk Altunyan", Answer = 1 });
            AllUsersAndAnswers.Add(new UserAnswers() { UserName = "Nikos Nikolayidis", Answer = 1 });

            Session["userData"] = AllUsersAndAnswers;
            //if (Session["userData"] == null)
            //{
            //    userAnswers = new List<UserAnswers>();
            //    userAnswers.Add(new UserAnswers() { UserName = userName, Answer = userAnswer });
            //    Session["userData"] = userAnswers;
            //}
            //else
            //{
            //    userAnswers = Session["userData"] as List<UserAnswers>;
            //    userAnswers.Add(new UserAnswers() { UserName = userName, Answer = userAnswer });
            //    Session["userData"] = userAnswers;
            //}
            

            #region IF-ELSE
            if (userAnswer == rightAnswer)
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (i == rightAnswer)
                        htmlTags += "greenClass";
                    else
                        htmlTags += "grayClass";
                }
            }
            else
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (i == rightAnswer)
                    {
                        htmlTags += "greenClass";
                        continue;
                    }
                    if (i == userAnswer)
                    {
                        htmlTags += "redClass";
                        continue;
                    }
                    htmlTags += "grayClass";
                }
            }
            #endregion


        }
        public void Online(string name)
        {

            using (StreamWriter file = new StreamWriter(@"F:\Git\LessonManagement\Diplom2017\Content\Online\WriteText.txt", true))
            {
                file.WriteLine(name);
            }

        }


        [HttpPost]
        public ActionResult ReadJson()
        {           
            return PartialView("_userQuestions", Session["myquestions"]);
        }

    }
}