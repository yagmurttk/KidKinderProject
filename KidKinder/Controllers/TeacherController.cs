using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [AllowAnonymous]
    public class TeacherController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult TeacherPartial()
        {
            var values = context.Teachers.ToList();
            return PartialView(values);
        }
        public PartialViewResult TeacherHeaderPartial()
        {
            return PartialView();
        }
    }
}