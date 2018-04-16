using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoteSystem.Models;

namespace VoteSystem.Controllers
{
    [Authentication]
    public class HomeController : Controller
    {
        // GET: Homes
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Search() {
            return View();
        }
        public ActionResult AllQuestion() {
            return View();
        }
        //投票页面
        public ActionResult Vote(int? voteId) {
            ViewBag.id = voteId;
            return View();
        }
        //注销
        [HttpPost]
        public ActionResult LogOff() {
            Response.Cookies["Menber"].Expires = DateTime.Now;//cookie将马上过期
            return RedirectToAction("Index");
        }
        
    }
}