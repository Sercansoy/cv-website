using ResumeProject.Models;
using ResumeProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class ExperienceController : Controller
    {
        ExperienceRepository repo = new ExperienceRepository();
        // GET: Experience
        public ActionResult Index()
        {
            var Experience = repo.List();
            return View(Experience);
        }
        [HttpGet]
        public ActionResult CreateExperience()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateExperience(Experience p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteExperience(int id)
        {
            Experience delete = repo.Find(x=>x.ExperienceID == id);
            if (delete != null)
                repo.TDelete(delete);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            Experience experience = repo.Find(x => x.ExperienceID == id);
            if (experience == null)
                return HttpNotFound();
            return View(experience);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateExperience(Experience p)
        {
            Experience experience = repo.Find(x => x.ExperienceID == p.ExperienceID);
            if (experience == null)
                return HttpNotFound();

            experience.Title = p.Title;
            experience.Company = p.Company;
            experience.Description = p.Description;
            experience.Date = p.Date;
            repo.TUpdate(experience);
            return RedirectToAction("Index");
        }
    }
}