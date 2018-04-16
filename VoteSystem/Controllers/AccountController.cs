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
    public class AccountController : Controller
    {
        // GET: Account
        [AllowAnonymous]
        public ActionResult Register()
        {
            ViewBag.returnUrl = Request.UrlReferrer;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegisterModel model, String returnUrl) {
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
                HttpCookie cookie = new HttpCookie("Menber");
                cookie.Values["ID"] = user.ID.ToString();
                cookie.Values["userNick"] = user.userNick;
                Response.Cookies.Add(cookie);
                return Redirect(returnUrl);
            }
        }
        [AllowAnonymous]
        public ActionResult Login() {
            ViewBag.returnUrl = Request.UrlReferrer;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model,String returnUrl)
        {
            if (!ModelState.IsValid) {
                ViewBag.res = "提交失败";
                return View(model);
            }
            UserDao userdao = new UserDao ();
            User user = new User();
            user.userEmail = model.userEmail;
            user.userPsw = model.userPsw;
            user = userdao.checkUser(user);
            if (user!=null) {
                HttpCookie cookie = new HttpCookie("Menber");
                cookie.Values["ID"] = user.ID.ToString();
                cookie.Values["userNick"] = user.userNick;
                Response.Cookies.Add(cookie);
                return Redirect(returnUrl);
            }
            else
                ViewBag.res = "登录失败";
            return View();
        }
        public Boolean checkByUserEmail() {
            return false;
        }

        public ActionResult Info() { 
            return View();
        }
        //修改密码
        public ActionResult ReSetPsw() {
            ReSetModel model = new Models.ReSetModel();
            model.ID = int.Parse(Request.Cookies["Menber"].Values["ID"]);
            return View(model);
        }
        [HttpPost]
        public ActionResult ResetPsw(ReSetModel model) {
            UserDao userdao = new Dao.UserDao();

            User user = userdao.getById(model.ID);
            if (user.userPsw.Equals(model.userPswOld)) {
                user.userPsw = model.userPswNew;
                userdao.ReSetPsw(user);
                ViewBag.res = "修改成功";
                return View();
            }
            ViewBag.res = "原密码不正确";
            return View();
        }
    }
}