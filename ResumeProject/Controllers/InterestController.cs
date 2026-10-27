using ResumeProject.Models;
using ResumeProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class InterestController : Controller
    {
        // GET: Interest
        GenericRepository<Interest> repo = new GenericRepository<Interest>();
        [HttpGet]
        public ActionResult Index()
        {
            var interest = repo.Find(x => x.InterestID == 1);
            return View(interest);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Interest p)
        {
            var Interest = repo.Find(x=>x.InterestID == 1);
            Interest.Title = p.Title;
            Interest.Description = p.Description;
            repo.TUpdate(Interest);

            TempData["Success"] = "Interest information has been updated.";
            return RedirectToAction("Index");
        }
    }
}