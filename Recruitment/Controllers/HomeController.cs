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

    public class HomeController : Controller
    {
        private RecruitmentEntities db = new RecruitmentEntities();

        public ActionResult Index()
        {
            var openJobs = db.OpenJobs.Include(o => o.Questionare).Include(o => o.WorkPosition);
            return View(openJobs.ToList());
        }
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

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}