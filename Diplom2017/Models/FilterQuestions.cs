using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom2017.Models
{
    public class FilterQuestions
    {
        //public string Themes { get; set; }
        //public List<string> ThemeQuestions { get; set; }
        public string Theme_Questions { get; set; }
        public override string ToString()
        {
            return Theme_Questions + "";
        }
    }
}