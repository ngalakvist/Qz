using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuizApp.Models;

namespace QuizApp.Abstract
{
    interface IQuizManager
    {
         Question LoadQuiz();
         void SaveAnswer(string answers);
         bool MoveToNextQuestion();
         bool PreviosQuestion();
    }
}
