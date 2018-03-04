using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom2017.Models
{
    public class Themes
    {
        public int id { get; set; }
        public string _Themes { get; set; }

        public override string ToString()
        {
            return _Themes + "";
        }
    }
}