using ResumeProject.Models;
using ResumeProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class CertificateController : Controller
    {
        CerificateRepository repo = new CerificateRepository();
        // GET: Certificate
        public ActionResult Index()
        {
            var certificates = repo.List();
            return View(certificates);
        }
        [HttpGet]
        public ActionResult EditCertificate(int id)
        {
            var find = repo.Find(x=>x.CertificateID == id);
            return View(find);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCertificate(Certificate certificate)
        {
            if (!ModelState.IsValid)
            {
                return View(certificate);
            }

            var find = repo.Find(x => x.CertificateID == certificate.CertificateID);
            find.Description = certificate.Description;
            find.Date = certificate.Date;
            repo.TUpdate(find);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCertificate(int id)
        {
            var delete = repo.Find(x=>x.CertificateID==id);
            if (delete != null)
                repo.TDelete(delete);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateCertificate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCertificate(Certificate p)
        {
            if (!ModelState.IsValid)
            {
                return View(p);
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
    }
}