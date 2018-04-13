using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VoteSystem.Dao;
using VoteSystem.Models;

namespace VoteSystem.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel model) {
            if (!ModelState.IsValid) {
                ViewBag.res = "提交失败";
                return View(model);
            }
            UserDao userdao = new UserDao();
            User user = new User();
            user.userNick = model.userNick;
            user.userEmail = model.userEmail;
            user.userPsw = model.userPsw;
            if (userdao.getByUserEmail(user.userEmail) != null)
            {
                ViewBag.res = "用户已存在";
                return View(model);
            }else {
                userdao.addUser(user);
                ViewBag.res = "注册成功";
                return View(model);
            }
        }
        public ActionResult Login() {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid) {
                ViewBag.res = "提交失败";
                return View(model);
            }
            UserDao userdao = new UserDao ();
            User user = new User();
            user.userEmail = model.userEmail;
            user.userPsw = model.userPsw;
            if (userdao.checkUser(user)!=null) {
                ViewBag.res = "登录成功";
            }
            else
                ViewBag.res = "登录失败";
            return View();
        }
        public Boolean checkByUserEmail() {
            return false;
        }

    }
}