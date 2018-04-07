using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Diplom2017.Models
{
    public class QuestAnswers
    {
        public string Subject { get; set; }
        public string Questions { get; set; }
        public int RightId { get; set; }

        public override string ToString()
        {
            return Questions + "";
        }
    }
}