using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Diplom2017.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
           
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"F:\Git\LessonManagement\Diplom2017\Content\Online\WriteText.txt", true))
            {
                file.WriteLine(name);
            }

        }
        public JsonResult ReadJson()
        {            
            string data;
            using (StreamReader r = new StreamReader(@"F:\Git\LessonManagement\Diplom2017\Content\Online\MyJSON1.json"))
            {
                data = r.ReadToEnd();
            }
            //return PartialView("_userQuestions", data);
            return Json(data);
        }
        public void CreateJson()
        {
            //JObject videogameRatings = new JObject(
            //             new JProperty("Subject", 9),                        
            //             new JProperty("Call of Duty", 7.5)
            //             );

            //System.IO.File.WriteAllText(@"F:\Git\LessonManagement\Diplom2017\Content\Online\WriteJSON.json", videogameRatings.ToString());

            //using (StreamWriter file = System.IO.File.CreateText(@"F:\Git\LessonManagement\Diplom2017\Content\Online\WriteJSON.json"))
            //using (JsonTextWriter writer = new JsonTextWriter(file))
            //{
            //    videogameRatings.WriteTo(writer);
            //}
            string json = " '{ \"Subject\": \"Intel\",\"Quests\": \"DVD read/writer\"}' ";
                        
            using (StreamWriter file = new StreamWriter(@"F:\Git\LessonManagement\Diplom2017\Content\Online\MyJSON1.json", true))
            {
                file.WriteLine(json);
            }

        }

    }
}