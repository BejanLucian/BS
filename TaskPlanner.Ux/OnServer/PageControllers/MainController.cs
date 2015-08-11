using System.Web.Mvc;

namespace TaskPlanner.Ux.OnServer.Controllers
{
    public class MainController : Controller
    {
        public PartialViewResult Index()
        {
            return PartialView();
        }

        public ActionResult Placeholder()
        {
            return View();
        }
    }
}