using Diplom2017.Models;
using Diplom2017.App_Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.IO;
using Newtonsoft.Json;

namespace Diplom2017
{
    

    public class AdminController : Controller
    {
        public static int questId;
        public static int currentThemeId;

        #region Login
        // POST: Admin
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
                                select new Lectures { _Lectures = lecture.Lectures, id = lecture.Id }).ToList();

                    themes = (from theme in db.Themes
                              join lecture in db.Lessons
                              on theme.Lesson_id equals lecture.Id
                              where lecture.Proffesor_Id == prof.Id && theme.Lesson_id == lecture.Id

                              select new Themes { _Themes = theme.Lect_themes, id = theme.id }).ToList();

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
        #endregion



        // [HttpPost] /////////////////////////////////////////////////////
        public ActionResult Index()
        {
            return View();
        }


        #region Admin DropDowns
        [HttpPost]
        public ActionResult UpdteQuestions(string index)
        {
            //Updating questions with Ajax
            //////////////////////////////

            int indx = Convert.ToInt32(index);

            currentThemeId = indx; ///////////////////////////////////////////////////////////////////////////////////////////

            List<FilterQuestions> data = null;

            using (DiplomeEntities db = new DiplomeEntities())
            {

                data = (from quest in db.AllQuestions
                        join theme in db.Themes
                        on quest.Theme_id equals theme.id
                        where theme.id == indx
                        select new FilterQuestions
                        {
                            Id = quest.Id,
                            Theme_Questions = quest.Question
                        }).ToList();
            }


            return PartialView("_question", data);
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

            return PartialView("_DropDowns", themes);
        }
        #endregion


        public ActionResult LoginProf()
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

            string hyp = "";
            if (text != null)
            {
                foreach (var it in text)
                {
                    hyp += $"<div> {it} <i class=\"my_badge\">&nbsp;</i></div>";
                }
            }

            return Content(hyp);
        }

        [HttpPost]
        public void CreateQuestion(string Id)/////////////////////////////////////////////////////////////////////////////////
        {
            int indx = Convert.ToInt32(Id);

            List<QuestAnswers> data = null;
            using (DiplomeEntities db = new DiplomeEntities())
            {

                data = (from quest in db.AllQuestions
                        join answ in db.AllAnswers
                        on quest.Id equals answ.AllQuest_Id
                        where quest.Id == indx

                        select new QuestAnswers
                        {
                            Subject = quest.Question,
                            Questions = answ.Answers,
                            RightId = answ.right_Answ_id
                        }).ToList();
            }

            questId = indx; //Question Id

            Session["myquestions"] = data;
           

        }

        [HttpPost]
        public ActionResult answerHtml()
        {
           
            return Json(OnlineStudentAnswersST.StudList);
        }

        public ActionResult Statistics()
        {

            ////////////////////////////////////////////

            List<StatiscticsModel> statistics = new List<StatiscticsModel>();
            using (DiplomeEntities db = new DiplomeEntities())
            {
                statistics = (from stud_answ in db.Stud_Answers
                              join student in db.Students
                              on stud_answ.stud_id equals student.Id
                              //where stud_answ.theme_id == currentThemeId

                              group stud_answ by new { student.Name , student.Surname, stud_answ.answer_data} into gr
                              select new StatiscticsModel { Name = gr.Key.Name + " " + gr.Key.Surname, Percent = gr.Average(g => g.answer_percent), Date = gr.Key.answer_data}).ToList();
            }
            var stat = JsonConvert.SerializeObject(statistics);
            Session["Statistics"] = stat;
            return View();
        }

        [HttpPost]
        public ActionResult Chart()
        {
            List<string> smartNames = new List<string>();
            List<string> badNames = new List<string>();
            List<string> alwaysSmart = new List<string>();

            int answersCount;

            using (DiplomeEntities db = new DiplomeEntities())
            {
                answersCount = db.StudAnswers_live.Select(s => s.Question_Id).Distinct().Count();

                smartNames = (from student in db.Students
                                join stud_answersLive in db.StudAnswers_live
                                on student.Id equals stud_answersLive.Stud_Id
                                where stud_answersLive.Stud_Answer == 1 && stud_answersLive.Question_Id == AdminController.questId
                                select student.Name + " " + student.Surname).ToList();

                badNames = (from student1 in db.Students
                                join stud_answersLive in db.StudAnswers_live
                                on student1.Id equals stud_answersLive.Stud_Id
                                where stud_answersLive.Stud_Answer == 0 && stud_answersLive.Question_Id == AdminController.questId
                                select student1.Name + " " + student1.Surname).ToList();

                alwaysSmart = (from student2 in db.Students
                               join stud_answersLive in db.StudAnswers_live
                               on student2.Id equals stud_answersLive.Stud_Id
                               where  stud_answersLive.Stud_Answer == 1
                               group stud_answersLive by new { stud_answersLive.Stud_Answer , student2.Name, student2.Surname } into g
                               where (g.Sum(p => p.Stud_Answer)) == answersCount
                               select  g.Key.Name + "" + g.Key.Surname ).ToList();

            }

            var smrtNames = JsonConvert.SerializeObject(smartNames);
            var bdNames = JsonConvert.SerializeObject(badNames);
            var alwSmart = JsonConvert.SerializeObject(alwaysSmart);

            return Json(new[] 
            {       
                    
                    smrtNames,
                    bdNames,
                    alwSmart
            });

        }



    }
}