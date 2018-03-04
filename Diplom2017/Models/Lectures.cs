using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom2017.Models
{
    public class Lectures
    {
        public int id { get; set; }
        public string _Lectures { get; set; }

        public override string ToString()
        {
            return _Lectures + "";
        }
    }
}