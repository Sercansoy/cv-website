using System.Web.Mvc;

namespace ResumeProject.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            Response.StatusCode = 500;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            Response.TrySkipIisCustomErrors = true;
            return View();
        }
    }
}