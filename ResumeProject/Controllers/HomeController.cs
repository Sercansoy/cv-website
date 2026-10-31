using ResumeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ResumeProject.Helpers;

namespace ResumeProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        Context db = new Context();
        private const int MaxMessagesPerHour = 3;
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
        public ActionResult SendMessage(Message message)
        {
            string back = Url.Action("Index", "Home") + "#contact";

            if (!string.IsNullOrEmpty(Request.Form["ref_code"]))
            {
                TempData["FormSuccess"] = "Thank you! Your message has been sent.";
                return Redirect(back);
            }

            // mesaj atma süresi: ip'den saat başına max mesaj sayısı
            string key = "contact:" + ClientIp.Get(Request);
            object cached = HttpRuntime.Cache[key];
            int sent = cached is int ? (int)cached : 0;

            if (sent >= MaxMessagesPerHour)
            {
                TempData["FormError"] = "Too many messages. Please try again later.";
                return Redirect(back);
            }

            // doğrulama
            ModelState.Remove("Date");
            if (!ModelState.IsValid)
            {
                TempData["FormError"] = "Please check the form and try again.";
                return Redirect(back);
            }

            message.Date = DateTime.Today;
            db.Messages.Add(message);
            db.SaveChanges();

            HttpRuntime.Cache.Insert(key, sent + 1, null,
                DateTime.UtcNow.AddHours(1), System.Web.Caching.Cache.NoSlidingExpiration);

            TempData["FormSuccess"] = "Thank you! Your message has been sent.";
            return Redirect(back);
        }

        public ActionResult DownloadCv()
        {
            string path = Server.MapPath("~/Content/files/Sercan_Soy_CV_web.pdf");

            if (!System.IO.File.Exists(path))
                return HttpNotFound();

            return File(path, "application/pdf", "Sercan_Soy_CV_web.pdf");
        }

    }
}