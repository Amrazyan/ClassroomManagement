using Diplom2017.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace Diplom2017.Controllers
{
    
    public class AdminController : Controller
    {

        // GET: Admin
        public ActionResult Index()
        {
            
            string email = "kristina@gmail.com";
            string password = "kristina";

            List<Quest> quens = null;

            using (App_Data.DiplomeEntities db = new App_Data.DiplomeEntities())
            {

                if (db.Proffesors.ToList().Exists(prof => prof.Email == email && prof.Password == password))
                {
                    var prof = db.Proffesors.Single(p => p.Email == email);

                    quens = (from quest in db.AllQuestions
                                                        join theme in db.Themes
                                                        on quest.Theme_id equals theme.id
                                                        join lessn in db.Lessons
                                                        on theme.Lesson_id equals lessn.Id
                                                        join prf in db.Proffesors
                                                        on lessn.Proffesor_Id equals prf.Id
                                                        where prf.Id == prof.Id

                                                        select new Quest
                                                        {
                                                            Question = quest.Question

                                                        }).ToList();
                }
            }
            Session["data"] = quens;

            return RedirectToAction("DayStatic");   
        }

        public ActionResult UpdteQuestions()
        {
            return View();
        }

        public ActionResult Statistics()
        {
            return View();
        }
        public ActionResult DayStatic()
        {
            return View();
        }

        public ActionResult OnlineUsers()
        {
             string[] text = System.IO.File.ReadAllLines(@"F:\Git\LessonManagement\Diplom2017\Content\Online\WriteText.txt");
            
            string hyp="";
            if (text!= null)
            {               
                foreach (var it in text)
                {
                    hyp += $"<div> {it} <i class=\"my_badge\">&nbsp;</i></div>";
                }
            }
            
            return Content(hyp);
        }
    }
}