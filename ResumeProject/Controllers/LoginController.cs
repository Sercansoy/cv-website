using ResumeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Caching;

namespace ResumeProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context db = new Context();

        private const int MaxAttempts = 5;
        private static readonly TimeSpan LockoutTime = TimeSpan.FromMinutes(15);

        private string GetClientIp()
        {
            string forwarded = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrWhiteSpace(forwarded))
            {
                // Azure'un ön sunucusu gerçek IP'yi listenin sonuna ekler
                string ip = forwarded.Split(',').Last().Trim();

                // "1.2.3.4:5678" biçimindeki IPv4 adreslerinden portu at
                int colon = ip.LastIndexOf(':');
                if (colon > -1 && ip.IndexOf(':') == colon)
                    ip = ip.Substring(0, colon);

                if (!string.IsNullOrEmpty(ip))
                    return ip;
            }

            // Yerelde (F5) başlık yoktur, eski yönteme dön
            return Request.UserHostAddress;
        }

        private string AttemptKey(string user)
        {
            return "login:" + GetClientIp() + ":" + (user ?? "").Trim().ToLowerInvariant();
        }

        private int GetAttempts(string key)
        {
            object value = HttpRuntime.Cache[key];
            return value is int ? (int)value : 0;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Admin p)
        {
            string key = AttemptKey(p.User);

            if (GetAttempts(key) >= MaxAttempts)
            {
                ViewBag.Error = "Too many failed attempts. Please try again in 15 minutes.";
                return View(new Admin { User = p.User });
            }

            var userinfo = db.Admins.FirstOrDefault(x => x.User == p.User);

            if (userinfo != null && PasswordIsValid(p.Password, userinfo.Password))
            {
                HttpRuntime.Cache.Remove(key);
                FormsAuthentication.SetAuthCookie(userinfo.User, false);
                Session["User"] = userinfo.User.ToString();
                return RedirectToAction("Index", "About");
            }

            HttpRuntime.Cache.Insert(key, GetAttempts(key) + 1, null,
                DateTime.UtcNow.Add(LockoutTime), Cache.NoSlidingExpiration);

            ViewBag.Error = "Invalid username or password.";
            return View(new Admin { User = p.User });
        }

        private bool PasswordIsValid(string entered, string storedHash)
        {
            if (string.IsNullOrEmpty(entered) || string.IsNullOrEmpty(storedHash))
                return false;

            try
            {
                return BCrypt.Net.BCrypt.Verify(entered, storedHash);
            }
            catch (BCrypt.Net.SaltParseException)
            {
                return false;
            }
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}