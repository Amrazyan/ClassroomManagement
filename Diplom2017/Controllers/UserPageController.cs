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
        public void Answers(int userAnswer, int rightAnswer)
        {
            string htmlTags = string.Empty;
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

            //List<QuestAnswers> data = null;
            //using (DiplomeEntities db = new DiplomeEntities())
            //{

            //    data = (from quest in db.AllQuestions
            //            join answ in db.AllAnswers
            //            on quest.Id equals answ.AllQuest_Id
            //            where quest.Id == 2

            //            select new QuestAnswers
            //            {
            //                Subject = quest.Question,
            //                Questions = answ.Answers,
            //            }).ToList();
            //}
           

            //Session["myquestions"] = data;

            return PartialView("_userQuestions", Session["myquestions"]);

        }
        public void CreateJson()
        {
            Session["my"] = stClass.myring;
            string json = " { \"Subject\":  \"Intel\" ,\"Quests\": [\"DVD read/writer\", \"DVD read/writer\",\"DVD read/writer\"]} ";

            using (StreamWriter file = new StreamWriter(@"F:\Git\LessonManagement\Diplom2017\Content\Online\MyJSON3.json", true))
            {
                file.WriteLine(json);
            }

        }

    }
}