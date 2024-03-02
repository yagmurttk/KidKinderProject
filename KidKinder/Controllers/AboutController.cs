using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [AllowAnonymous]
    public class AboutController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }
        public PartialViewResult AboutHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult AboutListPartial()
        {
            var values = context.AboutsLists.ToList();
            return PartialView(values);
        }
        public PartialViewResult AboutList2()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }
    }
}