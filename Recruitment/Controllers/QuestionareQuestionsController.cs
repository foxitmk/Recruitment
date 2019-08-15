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
    public class QuestionareQuestionsController : Controller
    {
        private RecruitmentEntities db = new RecruitmentEntities();

        // GET: QuestionareQuestions
        public ActionResult Index()
        {
            var questionareQuestions = db.QuestionareQuestions.Include(q => q.Questionare).Include(q => q.RepositoryOfQuestion);
            return View(questionareQuestions.ToList());
        }

        // GET: QuestionareQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionareQuestion questionareQuestion = db.QuestionareQuestions.Find(id);
            if (questionareQuestion == null)
            {
                return HttpNotFound();
            }
            return View(questionareQuestion);
        }

        // GET: QuestionareQuestions/Create
        public ActionResult Create()
        {
            ViewBag.Questionare_id = new SelectList(db.Questionares, "Questionare_id", "Description");
            ViewBag.RepositoryOfQuestions_id = new SelectList(db.RepositoryOfQuestions, "RepositoryOfQuestions_id", "Description");
            return View();
        }

        // POST: QuestionareQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QuestionareQuestions_id,Questionare_id,RepositoryOfQuestions_id")] QuestionareQuestion questionareQuestion)
        {
            if (ModelState.IsValid)
            {
                db.QuestionareQuestions.Add(questionareQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Questionare_id = new SelectList(db.Questionares, "Questionare_id", "Description", questionareQuestion.Questionare_id);
            ViewBag.RepositoryOfQuestions_id = new SelectList(db.RepositoryOfQuestions, "RepositoryOfQuestions_id", "Description", questionareQuestion.RepositoryOfQuestions_id);
            return View(questionareQuestion);
        }

        // GET: QuestionareQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionareQuestion questionareQuestion = db.QuestionareQuestions.Find(id);
            if (questionareQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Questionare_id = new SelectList(db.Questionares, "Questionare_id", "Description", questionareQuestion.Questionare_id);
            ViewBag.RepositoryOfQuestions_id = new SelectList(db.RepositoryOfQuestions, "RepositoryOfQuestions_id", "Description", questionareQuestion.RepositoryOfQuestions_id);
            return View(questionareQuestion);
        }

        // POST: QuestionareQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QuestionareQuestions_id,Questionare_id,RepositoryOfQuestions_id")] QuestionareQuestion questionareQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionareQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Questionare_id = new SelectList(db.Questionares, "Questionare_id", "Description", questionareQuestion.Questionare_id);
            ViewBag.RepositoryOfQuestions_id = new SelectList(db.RepositoryOfQuestions, "RepositoryOfQuestions_id", "Description", questionareQuestion.RepositoryOfQuestions_id);
            return View(questionareQuestion);
        }

        // GET: QuestionareQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionareQuestion questionareQuestion = db.QuestionareQuestions.Find(id);
            if (questionareQuestion == null)
            {
                return HttpNotFound();
            }
            return View(questionareQuestion);
        }

        // POST: QuestionareQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionareQuestion questionareQuestion = db.QuestionareQuestions.Find(id);
            db.QuestionareQuestions.Remove(questionareQuestion);
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
