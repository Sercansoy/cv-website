using ResumeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        Context db = new Context();
        // GET: Home
        public ActionResult Index()
        {
            var About = db.Abouts.ToList();
            return View(About);
        }
        public PartialViewResult Education()
        {
            var education = db.Educations.ToList();
            return PartialView(education);
        }
        public PartialViewResult Experience()
        {
            var experiences = db.Experiences.ToList();
            return PartialView(experiences);
        }
        public PartialViewResult Interest()
        {
            var interests = db.Interests.ToList();
            return PartialView(interests);
        }

        public PartialViewResult Skills()
        {
            var skill = db.Skills.ToList();
            return PartialView(skill);
        }
        public PartialViewResult Certificates()
        {
            var certificates = db.Certificates.ToList();
            return PartialView(certificates);
        }
        public PartialViewResult SocialMedia()
        {
            var socialmedia = db.Social_Medias.Where(x=>x.Status==true).ToList();
            return PartialView(socialmedia);
        }
        [HttpGet]
        public PartialViewResult contactTest()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult contactTest(Message message)
        {
            message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Messages.Add(message);
            db.SaveChanges();
            return PartialView();
        }

    }
}