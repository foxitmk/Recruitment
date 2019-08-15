using Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Recruitment.Filters;
using Recruitment.Models;

namespace Recruitment.Controllers
{
    [Localization("en")]
    public class QuestionaresController : Controller
    {
        private RecruitmentEntities db = new RecruitmentEntities();

        // GET: Questionares
        public ActionResult Index()
        {
            var questionares = db.Questionares;
            return View(questionares.ToList());
        }

        // GET: Questionares/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionare questionare = db.Questionares.Find(id);
            if (questionare == null)
            {
                return HttpNotFound();
            }
            return View(questionare);
        }

        // GET: Questionares/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Questionares/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Questionare_id,Description")] Questionare questionare)
        {
            if (ModelState.IsValid)
            {
                db.Questionares.Add(questionare);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questionare);
        }

        // GET: Questionares/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionare questionare = db.Questionares.Find(id);
            if (questionare == null)
            {
                return HttpNotFound();
            }
            return View(questionare);
        }

        // POST: Questionares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Questionare_id,Description")] Questionare questionare)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionare).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionare);
        }

        // GET: Questionares/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Questionare questionare = db.Questionares.Find(id);
            if (questionare == null)
            {
                return HttpNotFound();
            }
            return View(questionare);
        }

        // POST: Questionares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Questionare questionare = db.Questionares.Find(id);
            db.Questionares.Remove(questionare);
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
