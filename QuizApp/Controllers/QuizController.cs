using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApp.Models;
using QuizApp.ViewModels;
 

namespace QuizApp.Controllers
{
    public class QuizController : Controller
    {
        private QuizAppContext db = new QuizAppContext();

        public ActionResult Index()
        {
            QuizManager.Instance.questionId = 1;
            QuizManager.Instance.IsComplete = false;
            var question = QuizManager.Instance.LoadQuiz();
            if (question == null)
            {
                // DO something here to handle the error
                return null;
            }
            return View(question);
        }
        [HttpPost]
        public ActionResult Index(string answer, int questionId)
        {
            if (QuizManager.Instance.IsComplete) // Prevent score increase if backbutton is clicked and choice made
                return RedirectToAction("ShowResults");

            QuizManager.Instance.SaveAnswer(answer);
            if (QuizManager.Instance.MoveToNextQuestion())
            {
                var question = QuizManager.Instance.LoadQuiz();
                return View(question);
            }
            QuizManager.Instance.IsComplete = true;
            return RedirectToAction("ShowResults");
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult ShowResults()
        {
            var resultsViewModelList = new List<ResultsViewModel>();
            foreach (var item in QuizManager.Instance.ScoreTable)
            {
                var resultsViewModel = new ResultsViewModel();
                resultsViewModel.Questions= item.Question;
                resultsViewModel.RightAnswer = item.Answer;
                resultsViewModel.YourAnswer = item.AnswerFromUser;
                resultsViewModel.Score = item.Score;
                resultsViewModelList.Add(resultsViewModel);
            }
            return View(resultsViewModelList);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}