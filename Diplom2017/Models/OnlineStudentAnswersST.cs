using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom2017.Models
{
    public static class OnlineStudentAnswersST
    {
      private static List<string> _StudList = new List<string>();

        public static List<string> StudList { get { return _StudList; } set { _StudList = value; } }
      
    }
}