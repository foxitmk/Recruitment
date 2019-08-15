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
    public class WorkPositionsController : Controller
    {
        private RecruitmentEntities db = new RecruitmentEntities();

        // GET: WorkPositions
        public ActionResult Index()
        {
            return View(db.WorkPositions.ToList());
        }

        // GET: WorkPositions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkPosition workPosition = db.WorkPositions.Find(id);
            if (workPosition == null)
            {
                return HttpNotFound();
            }
            return View(workPosition);
        }

        // GET: WorkPositions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WorkPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WorkPosition_id,ShortDescription,LongDescription")] WorkPosition workPosition)
        {
            if (ModelState.IsValid)
            {
                db.WorkPositions.Add(workPosition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(workPosition);
        }

        // GET: WorkPositions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkPosition workPosition = db.WorkPositions.Find(id);
            if (workPosition == null)
            {
                return HttpNotFound();
            }
            return View(workPosition);
        }

        // POST: WorkPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WorkPosition_id,ShortDescription,LongDescription")] WorkPosition workPosition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(workPosition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(workPosition);
        }

        // GET: WorkPositions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WorkPosition workPosition = db.WorkPositions.Find(id);
            if (workPosition == null)
            {
                return HttpNotFound();
            }
            return View(workPosition);
        }

        // POST: WorkPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WorkPosition workPosition = db.WorkPositions.Find(id);
            db.WorkPositions.Remove(workPosition);
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
