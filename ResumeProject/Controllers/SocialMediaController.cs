using ResumeProject.Models;
using ResumeProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        SocialRepository repo = new SocialRepository();
        public ActionResult Index()
        {
            var media = repo.List();
            return View(media);
        }

        [HttpGet]
        public ActionResult AddMedia()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMedia(Social_media p)
        {
            if(!ModelState.IsValid)
                return View(p);
            p.Status = true;
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditMedia(int id)
        {
            var find = repo.Find(x => x.ID == id);
            return View(find);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMedia(Social_media p)
        {
            var find = repo.Find(x => x.ID == p.ID);
            find.Name = p.Name;
            find.Status = p.Status;
            find.Link = p.Link;
            find.Icon = p.Icon;
            repo.TUpdate(find);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteMedia(int id)
        {
            Social_media find = repo.Find(x => x.ID == id);
            find.Status = false;
            repo.TDelete(find);
            return RedirectToAction("Index");
        }
    }
}