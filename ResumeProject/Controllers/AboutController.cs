using ResumeProject.Models;
using ResumeProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        GenericRepository<About> repo = new GenericRepository<About>();
        [HttpGet]
        public ActionResult Index()
        {
            var about = repo.Find(x => x.ID == 1);
            return View(about);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(About p)
        {
            var about = repo.Find(x => x.ID == 1);
            about.FirstName = p.FirstName;
            about.LastName = p.LastName;
            about.Address = p.Address;
            about.PhoneNumber= p.PhoneNumber;
            about.EMail = p.EMail;
            about.Details  = p.Details;
            about.ImageUrl = p.ImageUrl;
            repo.TUpdate(about);
            TempData["Success"] = "About information has been updated.";
            return RedirectToAction("Index");
        }
    }
}