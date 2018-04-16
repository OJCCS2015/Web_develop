using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VoteSystem.Models
{
    public class AuthenticationAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);
            //如果控制器没有加AllowAnonymous特性或者Action没有加AllowAnonymous特性才检查
            if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) && !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                //此处写判断是否登录的逻辑代码
                //这里使用cookie来判断是否登录，为了简单说明特性的使用方式，cookie记录的是用户名和明文密码(实际当中需要经过诸如加密等处理)
                HttpCookie cookie = filterContext.HttpContext.Request.Cookies["Menber"];
                //当用户没有登录是跳转到登录页面
                if (cookie == null)
                {
                    filterContext.Result = new RedirectResult("/Account/Login");
                }
            }
        }
    }
}