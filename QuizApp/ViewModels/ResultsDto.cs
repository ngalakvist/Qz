using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizApp.ViewModels
{
    public class ResultsDto
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public string AnswerFromUser { get; set; }
        public int Score { get; set; }
    }
}