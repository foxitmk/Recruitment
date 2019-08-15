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
    public class OpenJobsController : Controller
    {
        private RecruitmentEntities db = new RecruitmentEntities();

        // GET: OpenJobs
        public ActionResult Index()
        {
            var openJobs = db.OpenJobs.Include(o => o.Questionare).Include(o => o.WorkPosition);
            return View(openJobs.ToList());
        }

        // GET: OpenJobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenJob openJob = db.OpenJobs.Find(id);
            if (openJob == null)
            {
                return HttpNotFound();
            }
            return View(openJob);
        }

        // GET: OpenJobs/Create
        public ActionResult Create()
        {
            ViewBag.Questionare_id = new SelectList(db.Questionares, "Questionare_id", "Description");
            ViewBag.WorkPosition_id = new SelectList(db.WorkPositions, "WorkPosition_id", "ShortDescription");
            return View();
        }

        // POST: OpenJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OpenJobs_id,WorkPosition_id,Conditions,ValidFrom,ValidTo,Questionare_id")] OpenJob openJob)
        {
            if (ModelState.IsValid)
            {
                db.OpenJobs.Add(openJob);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Questionare_id = new SelectList(db.Questionares, "Questionare_id", "Description", openJob.Questionare_id);
            ViewBag.WorkPosition_id = new SelectList(db.WorkPositions, "WorkPosition_id", "ShortDescription", openJob.WorkPosition_id);
            return View(openJob);
        }

        // GET: OpenJobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenJob openJob = db.OpenJobs.Find(id);
            if (openJob == null)
            {
                return HttpNotFound();
            }
            ViewBag.Questionare_id = new SelectList(db.Questionares, "Questionare_id", "Description", openJob.Questionare_id);
            ViewBag.WorkPosition_id = new SelectList(db.WorkPositions, "WorkPosition_id", "ShortDescription", openJob.WorkPosition_id);
            return View(openJob);
        }

        // POST: OpenJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OpenJobs_id,WorkPosition_id,Conditions,ValidFrom,ValidTo,Questionare_id")] OpenJob openJob)
        {
            if (ModelState.IsValid)
            {
                db.Entry(openJob).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Questionare_id = new SelectList(db.Questionares, "Questionare_id", "Description", openJob.Questionare_id);
            ViewBag.WorkPosition_id = new SelectList(db.WorkPositions, "WorkPosition_id", "ShortDescription", openJob.WorkPosition_id);
            return View(openJob);
        }

        // GET: OpenJobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenJob openJob = db.OpenJobs.Find(id);
            if (openJob == null)
            {
                return HttpNotFound();
            }
            return View(openJob);
        }

        // POST: OpenJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OpenJob openJob = db.OpenJobs.Find(id);
            db.OpenJobs.Remove(openJob);
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
