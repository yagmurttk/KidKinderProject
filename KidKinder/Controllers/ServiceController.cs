using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [AllowAnonymous]
    public class ServiceController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ServicePartial()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }
        public PartialViewResult ServiceHeaderPartial()
        {
            return PartialView();
        }
    }
}