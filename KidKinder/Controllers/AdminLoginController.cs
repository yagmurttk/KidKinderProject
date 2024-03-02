using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KidKinder.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var result = context.Admins.Where(x => x.Username == admin.Username && x.Password == admin.Password).FirstOrDefault();
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(admin.Username, false);
                Session["Username"] = result.Username;
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı!!");
                return View(admin);
            }
        }
    }
}
