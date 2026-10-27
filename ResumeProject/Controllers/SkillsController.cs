using ResumeProject.Models;
using ResumeProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        GenericRepository<Skills> repo = new GenericRepository<Skills>();
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSkill(Skills model)
        {
            if (model == null || !ModelState.IsValid)
                return View(model);
            if (model.IsLearning)
                model.Progress = 0;

            repo.TAdd(model);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSkill(int id)
        {
            var delete = repo.Find(x=>x.ID == id);
            if (delete != null)
                repo.TDelete(delete);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            Skills T = repo.Find(x => x.ID == id);
            return View(T);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSkill(Skills model)
        {
            Skills T = repo.Find(x => x.ID == model.ID);
            if (T == null)
                return HttpNotFound();

            T.Skill = model.Skill;
            T.Icon = model.Icon;
            T.IsLearning = model.IsLearning;
            T.Progress = model.IsLearning ? (byte)0 : model.Progress;
            repo.TUpdate(T);
            return RedirectToAction("Index");
        }
    }
}