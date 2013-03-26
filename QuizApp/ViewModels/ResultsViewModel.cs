using QuizApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
namespace QuizApp.ViewModels
{
    public class ResultsViewModel
    {
        public string Questions { get; set; }
        public string YourAnswer { get; set; }
        public string RightAnswer { get; set; }
        public int Points { get; set; }
        public int Score { get; set; }
        public int TotalNumberOfQuestons { get; set; }
    }
}