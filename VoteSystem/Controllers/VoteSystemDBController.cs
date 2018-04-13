using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoteSystem.Dao;
using VoteSystem.Models;
namespace VoteSystem.Controllers
{
    public class VoteSystemDBController : Controller
    {
        private VoteSystemDB db = new VoteSystemDB();
        // GET: VoteSystemDB
        public ActionResult Index()
        {
            User u1 = new User();
            User u2 = new User();
             
            u1.userNick = "小明";
            u2.userNick = "小李";

            db.users.Add(u1);
            db.users.Add(u2);

            db.SaveChanges();
            var users = db.users;
            return View(users.ToList());
        }
        public ActionResult Demo() {
            UserDao userdao = new UserDao();
            User user = new User();
            user.userEmail = "392788234@qq.com";
            user.userPsw = "123456789";
            User u = userdao.checkUser(user);
            if (u!=null)
                ViewBag.res = true;
            else ViewBag.res = false;
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}