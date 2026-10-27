using ResumeProject.Models;
using ResumeProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<Admin> repo = new GenericRepository<Admin>();
        public ActionResult Index()
        {
            var list = repo.List();
            return View(list);
        }
        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAdmin(Admin p)
        {
            if (string.IsNullOrWhiteSpace(p.User) || string.IsNullOrWhiteSpace(p.Password) || p.Password.Length < 8)
            {
                ModelState.AddModelError("Password", "Password must be at least 8 characters.");
                return View(p);
            }

            p.Password = BCrypt.Net.BCrypt.HashPassword(p.Password);
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAdmin(int id)
        {
            Admin admin = repo.Find(x => x.AdminID == id);
            if (admin == null)
                return RedirectToAction("Index");

            if (repo.List().Count <= 1)
            {
                TempData["Error"] = "You cannot delete the last admin.";
                return RedirectToAction("Index");
            }

            if (admin.User == User.Identity.Name)
            {
                TempData["Error"] = "You cannot delete your own account.";
                return RedirectToAction("Index");
            }

            repo.TDelete(admin);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            Admin admin = repo.Find(x => x.AdminID == id);
            if (admin == null)
                return HttpNotFound();
            return View(admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateAdmin(Admin p)
        {
            Admin admin = repo.Find(x => x.AdminID == p.AdminID);
            if (admin == null)
                return HttpNotFound();

            admin.User = p.User;

            if (!string.IsNullOrWhiteSpace(p.Password))
            {
                admin.Password = BCrypt.Net.BCrypt.HashPassword(p.Password);
            }

            repo.TUpdate(admin);
            return RedirectToAction("Index");
        }
    }
}