using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Recruitment.Models;

namespace Recruitment.Controllers
{
    public class QuestionareAnswersController : Controller
    {
        private RecruitmentEntities db = new RecruitmentEntities();

        // GET: QuestionareAnswers
        public ActionResult Index()
        {
            var questionareAnswers = db.QuestionareAnswers.Include(q => q.Aplication).Include(q => q.RepositoryOfAnswer).Include(q => q.RepositoryOfQuestion);
            return View(questionareAnswers.ToList());
        }

        // GET: QuestionareAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionareAnswer questionareAnswer = db.QuestionareAnswers.Find(id);
            if (questionareAnswer == null)
            {
                return HttpNotFound();
            }
            return View(questionareAnswer);
        }

        // GET: QuestionareAnswers/Create
        public ActionResult Create()
        {
            ViewBag.Aplication_id = new SelectList(db.Aplications, "Aplication_id", "FirstName");
            ViewBag.RepositoryOfAnswers_id = new SelectList(db.RepositoryOfAnswers, "RepositoryOfAnswers_id", "Description");
            ViewBag.RepositoryOfQuestions_id = new SelectList(db.RepositoryOfQuestions, "RepositoryOfQuestions_id", "Description");
            return View();
        }

        // POST: QuestionareAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionareAnswers_id,Aplication_id,RepositoryOfAnswers_id,RepositoryOfQuestions_id")] QuestionareAnswer questionareAnswer)
        {
            if (ModelState.IsValid)
            {
                db.QuestionareAnswers.Add(questionareAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Aplication_id = new SelectList(db.Aplications, "Aplication_id", "FirstName", questionareAnswer.Aplication_id);
            ViewBag.RepositoryOfAnswers_id = new SelectList(db.RepositoryOfAnswers, "RepositoryOfAnswers_id", "Description", questionareAnswer.RepositoryOfAnswers_id);
            ViewBag.RepositoryOfQuestions_id = new SelectList(db.RepositoryOfQuestions, "RepositoryOfQuestions_id", "Description", questionareAnswer.RepositoryOfQuestions_id);
            return View(questionareAnswer);
        }

        // GET: QuestionareAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionareAnswer questionareAnswer = db.QuestionareAnswers.Find(id);
            if (questionareAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Aplication_id = new SelectList(db.Aplications, "Aplication_id", "FirstName", questionareAnswer.Aplication_id);
            ViewBag.RepositoryOfAnswers_id = new SelectList(db.RepositoryOfAnswers, "RepositoryOfAnswers_id", "Description", questionareAnswer.RepositoryOfAnswers_id);
            ViewBag.RepositoryOfQuestions_id = new SelectList(db.RepositoryOfQuestions, "RepositoryOfQuestions_id", "Description", questionareAnswer.RepositoryOfQuestions_id);
            return View(questionareAnswer);
        }

        // POST: QuestionareAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionareAnswers_id,Aplication_id,RepositoryOfAnswers_id,RepositoryOfQuestions_id")] QuestionareAnswer questionareAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionareAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Aplication_id = new SelectList(db.Aplications, "Aplication_id", "FirstName", questionareAnswer.Aplication_id);
            ViewBag.RepositoryOfAnswers_id = new SelectList(db.RepositoryOfAnswers, "RepositoryOfAnswers_id", "Description", questionareAnswer.RepositoryOfAnswers_id);
            ViewBag.RepositoryOfQuestions_id = new SelectList(db.RepositoryOfQuestions, "RepositoryOfQuestions_id", "Description", questionareAnswer.RepositoryOfQuestions_id);
            return View(questionareAnswer);
        }

        // GET: QuestionareAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionareAnswer questionareAnswer = db.QuestionareAnswers.Find(id);
            if (questionareAnswer == null)
            {
                return HttpNotFound();
            }
            return View(questionareAnswer);
        }

        // POST: QuestionareAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionareAnswer questionareAnswer = db.QuestionareAnswers.Find(id);
            db.QuestionareAnswers.Remove(questionareAnswer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
