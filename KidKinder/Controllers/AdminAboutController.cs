using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminAboutController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var value = context.Abouts.FirstOrDefault();
            return View(value);
        }
        public ActionResult UpdateAbout(int id)
        {
            var value = context.Abouts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About model)
        {
            var value = context.Abouts.Find(model.AboutId);
            value.BigImageUrl = model.BigImageUrl;
            value.Description = model.Description;
            value.Header = model.Header;
            value.Title = model.Title;
            value.SmallImageUrl = model.SmallImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}