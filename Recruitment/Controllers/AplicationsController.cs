﻿using System;
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
    public class AplicationsController : Controller
    {
        private RecruitmentEntities db = new RecruitmentEntities();

        // GET: Aplications
        public ActionResult Index()
        {
            var aplications = db.Aplications.Include(a => a.OpenJob).Include(a => a.WorkPosition);
            return View(aplications.ToList());
        }

        // GET: Aplications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplication aplication = db.Aplications.Find(id);
            if (aplication == null)
            {
                return HttpNotFound();
            }
            return View(aplication);
        }

        // GET: Aplications/Create
        public ActionResult Create( int? OpenJobs_id,int? WorkPosition_id)
        {
            if (OpenJobs_id != null)
            {
                ViewBag.OpenJobs_id = new SelectList(db.OpenJobs.Where(c => c.OpenJobs_id == OpenJobs_id), "OpenJobs_id", "Conditions");
            }
            else
            {
                ViewBag.OpenJobs_id = new SelectList(db.OpenJobs, "OpenJobs_id", "Conditions");
            }

            if(WorkPosition_id != null)
            {
                ViewBag.WorkPosition_id = new SelectList(db.WorkPositions.Where(c => c.WorkPosition_id == WorkPosition_id), "WorkPosition_id", "ShortDescription");
            }
            else
            {
                ViewBag.WorkPosition_id = new SelectList(db.WorkPositions, "WorkPosition_id", "ShortDescription");
            }


            var openJob = db.OpenJobs.FirstOrDefault(c => c.OpenJobs_id == OpenJobs_id);
            if (openJob != null )
            {
                ViewBag.QuestionareQuestions = db.QuestionareQuestions.Where(c => c.Questionare_id == openJob.Questionare_id).Include(c => c.RepositoryOfQuestion).ToList();
            }


            return View();
        }

        // POST: Aplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Aplication_id,FirstName,LastName,Address,City,DateOfBirth,Phone,Email,CV,Accepted,OpenJobs_id,WorkPosition_id")] Aplication aplication,FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                db.Aplications.Add(aplication);
                db.SaveChanges();
                string [] prasanja = formCollection["Prasanja"].Split(',');
                string [] odgovori = formCollection["Odgovori"].Split(',');
                for (int i=0; i<prasanja.Length; i++)
                {
                    QuestionareAnswer questionareAnswer = new QuestionareAnswer();
                    questionareAnswer.RepositoryOfAnswers_id =Convert.ToInt32 (odgovori [i]);
                    questionareAnswer.RepositoryOfQuestions_id =Convert.ToInt32( prasanja [i]);
                    questionareAnswer.Aplication_id = aplication.Aplication_id;
                    db.QuestionareAnswers.Add(questionareAnswer);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            ViewBag.OpenJobs_id = new SelectList(db.OpenJobs, "OpenJobs_id", "Conditions", aplication.OpenJobs_id);
            ViewBag.WorkPosition_id = new SelectList(db.WorkPositions, "WorkPosition_id", "ShortDescription", aplication.WorkPosition_id);
            return View(aplication);
        }

        // GET: Aplications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplication aplication = db.Aplications.Find(id);
            if (aplication == null)
            {
                return HttpNotFound();
            }
            ViewBag.OpenJobs_id = new SelectList(db.OpenJobs, "OpenJobs_id", "Conditions", aplication.OpenJobs_id);
            ViewBag.WorkPosition_id = new SelectList(db.WorkPositions, "WorkPosition_id", "ShortDescription", aplication.WorkPosition_id);
            return View(aplication);
        }

        // POST: Aplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Aplication_id,FirstName,LastName,Address,City,DateOfBirth,Phone,Email,CV,Accepted,OpenJobs_id,WorkPosition_id")] Aplication aplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OpenJobs_id = new SelectList(db.OpenJobs, "OpenJobs_id", "Conditions", aplication.OpenJobs_id);
            ViewBag.WorkPosition_id = new SelectList(db.WorkPositions, "WorkPosition_id", "ShortDescription", aplication.WorkPosition_id);
            return View(aplication);
        }

        // GET: Aplications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplication aplication = db.Aplications.Find(id);
            if (aplication == null)
            {
                return HttpNotFound();
            }
            return View(aplication);
        }

        // POST: Aplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aplication aplication = db.Aplications.Find(id);
            db.Aplications.Remove(aplication);
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
