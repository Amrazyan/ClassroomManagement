using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom2017.Models
{
    public class StatisticLists
    {
        public string Name { get; set; }
        public List<double> Percents { get; set; }
        public List<DateTime> Datas { get; set; }

    }
}