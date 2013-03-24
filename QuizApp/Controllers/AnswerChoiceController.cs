using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuizApp.Models;

namespace QuizApp.Controllers
{
    public class AnswerChoiceController : Controller
    {
        private QuizAppContext db = new QuizAppContext();

        //
        // GET: /AnswerChoice/

        public ActionResult Index()
        {
            var answerchoices = db.AnswerChoices.Include(a => a.Question);
            return View(answerchoices.ToList());
        }

        //
        // GET: /AnswerChoice/Details/5

        public ActionResult Details(int id = 0)
        {
            AnswerChoice answerchoice = db.AnswerChoices.Find(id);
            if (answerchoice == null)
            {
                return HttpNotFound();
            }
            return View(answerchoice);
        }

        //
        // GET: /AnswerChoice/Create

        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionText");
            return View();
        }

        //
        // POST: /AnswerChoice/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnswerChoice answerchoice)
        {
            if (ModelState.IsValid)
            {
                db.AnswerChoices.Add(answerchoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionText", answerchoice.QuestionId);
            return View(answerchoice);
        }

        //
        // GET: /AnswerChoice/Edit/5

        public ActionResult Edit(int id = 0)
        {
            AnswerChoice answerchoice = db.AnswerChoices.Find(id);
            if (answerchoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionText", answerchoice.QuestionId);
            return View(answerchoice);
        }

        //
        // POST: /AnswerChoice/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnswerChoice answerchoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(answerchoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionText", answerchoice.QuestionId);
            return View(answerchoice);
        }

        //
        // GET: /AnswerChoice/Delete/5

        public ActionResult Delete(int id = 0)
        {
            AnswerChoice answerchoice = db.AnswerChoices.Find(id);
            if (answerchoice == null)
            {
                return HttpNotFound();
            }
            return View(answerchoice);
        }

        //
        // POST: /AnswerChoice/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnswerChoice answerchoice = db.AnswerChoices.Find(id);
            db.AnswerChoices.Remove(answerchoice);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}