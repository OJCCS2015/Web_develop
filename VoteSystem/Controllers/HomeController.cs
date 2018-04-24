using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoteSystem.Dao;
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
            IndexModel model = new IndexModel();
            TagDao tagdao = new TagDao();

            model.tags = tagdao.getTagList(0,3);

            return View(model);
        }
        public ActionResult Search() {
            return View();
        }
        //发布问题
        public ActionResult Publish() {
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
        //查看已发布的问题
        public ActionResult MyPublish() {
            return View();
        }
        //查看已投票的问题
        public ActionResult MyVote() {
            return View();
        }
    }
}