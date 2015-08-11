using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskPlanner.Ux.OnServer.Controllers
{
    public class TaskController : Controller
    {
        // GET: Tasks
        public PartialViewResult Index()
        {
            return PartialView();
        }
    }
}