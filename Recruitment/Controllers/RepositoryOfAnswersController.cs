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
    public class RepositoryOfAnswersController : Controller
    {
        private RecruitmentEntities db = new RecruitmentEntities();

        // GET: RepositoryOfAnswers
        public ActionResult Index()
        {
            var repositoryOfAnswers = db.RepositoryOfAnswers.Include(r => r.Answer);
            return View(repositoryOfAnswers.ToList());
        }

        // GET: RepositoryOfAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepositoryOfAnswer repositoryOfAnswer = db.RepositoryOfAnswers.Find(id);
            if (repositoryOfAnswer == null)
            {
                return HttpNotFound();
            }
            return View(repositoryOfAnswer);
        }

        // GET: RepositoryOfAnswers/Create
        public ActionResult Create()
        {
            ViewBag.Answers_id = new SelectList(db.Answers, "Answers_id", "Desrciption");
            return View();
        }

        // POST: RepositoryOfAnswers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RepositoryOfAnswers_id,Answers_id,Description")] RepositoryOfAnswer repositoryOfAnswer)
        {
            if (ModelState.IsValid)
            {
                db.RepositoryOfAnswers.Add(repositoryOfAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Answers_id = new SelectList(db.Answers, "Answers_id", "Desrciption", repositoryOfAnswer.Answers_id);
            return View(repositoryOfAnswer);
        }

        // GET: RepositoryOfAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepositoryOfAnswer repositoryOfAnswer = db.RepositoryOfAnswers.Find(id);
            if (repositoryOfAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Answers_id = new SelectList(db.Answers, "Answers_id", "Desrciption", repositoryOfAnswer.Answers_id);
            return View(repositoryOfAnswer);
        }

        // POST: RepositoryOfAnswers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RepositoryOfAnswers_id,Answers_id,Description")] RepositoryOfAnswer repositoryOfAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repositoryOfAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Answers_id = new SelectList(db.Answers, "Answers_id", "Desrciption", repositoryOfAnswer.Answers_id);
            return View(repositoryOfAnswer);
        }

        // GET: RepositoryOfAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepositoryOfAnswer repositoryOfAnswer = db.RepositoryOfAnswers.Find(id);
            if (repositoryOfAnswer == null)
            {
                return HttpNotFound();
            }
            return View(repositoryOfAnswer);
        }

        // POST: RepositoryOfAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepositoryOfAnswer repositoryOfAnswer = db.RepositoryOfAnswers.Find(id);
            db.RepositoryOfAnswers.Remove(repositoryOfAnswer);
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
