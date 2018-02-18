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
                   // $"<h4> <span class=\"badge badge-success\">{it}</span></h4> ";
                }
            }
            
            return Content(hyp);
        }
    }
}