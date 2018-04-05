using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VoteSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Homes
        public ActionResult Index()
        {
            return View();
        }
    }
}