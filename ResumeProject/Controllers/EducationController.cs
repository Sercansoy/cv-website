using ResumeProject.Models;
using ResumeProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        EducationRepository repo = new EducationRepository();
        public ActionResult Index()
        {
            var education = repo.List();
            return View(education);
        }

        [HttpGet]
        public ActionResult AddEducation()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddEducation(Education p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteEducation(int id)
        {
            var delete = repo.Find(x => x.EducationID == id);
            if (delete != null)
                repo.TDelete(delete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditEducation (int id)
        {
            var find = repo.Find(x=>x.EducationID==id);
            return View(find);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditEducation(Education p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            var find = repo.Find(x => x.EducationID == p.EducationID);
            find.Title = p.Title;
            find.SubTitle = p.SubTitle;
            find.Date = p.Date;
            repo.TUpdate(find);
            return RedirectToAction("Index");
        }
    }
}