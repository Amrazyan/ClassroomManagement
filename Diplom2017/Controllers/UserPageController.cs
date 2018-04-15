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
        public void Answers(string userAnswer, string userId, string rightIndex, string selectedIndex) //Stugel
        {
           
            string htmlTags = string.Empty;

            int userAnswerr = Convert.ToInt32(userAnswer); // change
            int userID = Convert.ToInt32(userId);
            int rightindex = Convert.ToInt32(rightIndex);
            int slctindex = Convert.ToInt32(selectedIndex);

            StudAnswers_live studAnswLive = new StudAnswers_live() { Stud_Id = userID, Question_Id = AdminController.questId, Stud_Answer = userAnswerr, Data = DateTime.UtcNow.Date };                             

            using (DiplomeEntities db = new DiplomeEntities())
            {            
                db.StudAnswers_live.Add(studAnswLive);
                
                db.SaveChanges();
            }

            htmlTags += "<div class='col-sm-3 col-xs'> <div class='card card-3'>";
            htmlTags += "<p>Arman Amrazyan</p>";

            #region IF-ELSE
            if (userAnswerr == 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == rightindex)
                        htmlTags += "<div class='test test-gr'></div>";
                    else
                        htmlTags += "<div class='test'></div>";
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    if (i == rightindex)
                    {
                        htmlTags += "<div class='test test-gr'></div>";
                        continue;
                    }
                    if (i == slctindex)
                    {
                        htmlTags += "<div class='test test-red'></div>";
                        continue;
                    }
                    htmlTags += "<div class='test'></div>";
                }
            }
            #endregion

            htmlTags += "</div> </div>";
            OnlineStudentAnswersST.StudList.Add(htmlTags);

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