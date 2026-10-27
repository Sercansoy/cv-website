using ResumeProject.Models;
using ResumeProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        GenericRepository<Message> repo = new GenericRepository<Message>();
        public ActionResult Index()
        {
            var messages = repo.List();
            return View(messages);
        }
    }
}