using Diplom2017.Models;
using Diplom2017.App_Data;
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
        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            
            //string email = "kristina@gmail.com";
            //string password = "kristina";

            List<FilterQuestions> quens = null;
            List<Lectures> lections = null;
            List<Themes> themes = null;

            using (DiplomeEntities db = new DiplomeEntities())
            {

                if (db.Proffesors.ToList().Exists(prof => prof.Email == email && prof.Password == password))
                {

                    var prof = db.Proffesors.Single(p => p.Email == email);
                    Session["prof"] = prof.Name + " " + prof.Surname;
                        quens = (from quest in db.AllQuestions
                                    join theme in db.Themes
                                    on quest.Theme_id equals theme.id
                                    join lessn in db.Lessons
                                    on theme.Lesson_id equals lessn.Id                                   
                                    where lessn.Id == prof.Id

                                    select new FilterQuestions
                                    {                                        
                                        Theme_Questions = quest.Question
                                    }).ToList();

                    lections = (from lecture in db.Lessons
                               where lecture.Proffesor_Id == prof.Id
                               select new Lectures {_Lectures = lecture.Lectures, id = lecture.Id }).ToList();

                    themes = (from theme in db.Themes
                              join lecture in db.Lessons
                              on theme.Lesson_id equals lecture.Id
                              where lecture.Proffesor_Id == prof.Id && theme.Lesson_id == lecture.Id

                              select new Themes{ _Themes = theme.Lect_themes,id = theme.id }).ToList();

                    Session["lections"] = lections;
                    Session["themes"] = themes;
                    //Session["date"] = null;

                    return RedirectToAction("DayStatic");

                }
                else
                {
                    ModelState.AddModelError("Error", "Wrong login or password");
                }
            }//Calling Dispose method
            
            return View("LoginProf");   
        }

        [HttpPost]
        public ActionResult UpdteQuestions(string index)
        {
            //Updating questions with Ajax
            //////////////////////////////

            int indx = Convert.ToInt32(index);
            List<FilterQuestions> data = null;

            using (DiplomeEntities db = new DiplomeEntities())
            {
             
                data = (from quest in db.AllQuestions
                        join theme in db.Themes
                        on quest.Theme_id equals theme.id
                        where theme.id == indx
                        select new FilterQuestions {                            
                            Theme_Questions = quest.Question
                        }).ToList();
            }
           

            return PartialView("_question",data);
        }
        public ActionResult UpdteQuestions()
        {
            //Updating questions with Ajax
            //////////////////////////////



            return View();
        }
        [HttpPost]
        public ActionResult _updtTheme(string index)
        {
            //Updating themes with Ajax
            //////////////////////////////

            int indx = Convert.ToInt32(index);
            List<Themes> themes = null;
            using (DiplomeEntities db = new DiplomeEntities())
            {

                themes = (from theme in db.Themes
                          join lecture in db.Lessons
                          on theme.Lesson_id equals lecture.Id
                          where theme.Lesson_id == indx

                          select new Themes { _Themes = theme.Lect_themes, id = theme.id }).ToList();
            }
            Session["themes"] = themes;
            string indxx = (themes.First(x => x.id == x.id)).id.ToString();
            //RedirectToAction()
            RedirectToAction("UpdteQuestions", "Admin", indxx);
            return PartialView("_Lecture", themes);
        }


        public ActionResult LoginProf()
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