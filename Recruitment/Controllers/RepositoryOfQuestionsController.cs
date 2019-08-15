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
    public class RepositoryOfQuestionsController : Controller
    {
        private RecruitmentEntities db = new RecruitmentEntities();

        // GET: RepositoryOfQuestions
        public ActionResult Index()
        {
            var repositoryOfQuestions = db.RepositoryOfQuestions.Include(r => r.Answer);
            return View(repositoryOfQuestions.ToList());
        }

        // GET: RepositoryOfQuestions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepositoryOfQuestion repositoryOfQuestion = db.RepositoryOfQuestions.Find(id);
            if (repositoryOfQuestion == null)
            {
                return HttpNotFound();
            }
            return View(repositoryOfQuestion);
        }

        // GET: RepositoryOfQuestions/Create
        public ActionResult Create()
        {
            ViewBag.Answer_id = new SelectList(db.Answers, "Answers_id", "Desrciption");
            return View();
        }

        // POST: RepositoryOfQuestions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RepositoryOfQuestions_id,Description,Answer_id")] RepositoryOfQuestion repositoryOfQuestion)
        {
            if (ModelState.IsValid)
            {
                db.RepositoryOfQuestions.Add(repositoryOfQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Answer_id = new SelectList(db.Answers, "Answers_id", "Desrciption", repositoryOfQuestion.Answer_id);
            return View(repositoryOfQuestion);
        }

        // GET: RepositoryOfQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepositoryOfQuestion repositoryOfQuestion = db.RepositoryOfQuestions.Find(id);
            if (repositoryOfQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.Answer_id = new SelectList(db.Answers, "Answers_id", "Desrciption", repositoryOfQuestion.Answer_id);
            return View(repositoryOfQuestion);
        }

        // POST: RepositoryOfQuestions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RepositoryOfQuestions_id,Description,Answer_id")] RepositoryOfQuestion repositoryOfQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repositoryOfQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Answer_id = new SelectList(db.Answers, "Answers_id", "Desrciption", repositoryOfQuestion.Answer_id);
            return View(repositoryOfQuestion);
        }

        // GET: RepositoryOfQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RepositoryOfQuestion repositoryOfQuestion = db.RepositoryOfQuestions.Find(id);
            if (repositoryOfQuestion == null)
            {
                return HttpNotFound();
            }
            return View(repositoryOfQuestion);
        }

        // POST: RepositoryOfQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RepositoryOfQuestion repositoryOfQuestion = db.RepositoryOfQuestions.Find(id);
            db.RepositoryOfQuestions.Remove(repositoryOfQuestion);
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
