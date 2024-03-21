using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminFeatureController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Features.FirstOrDefault();
            return View(values);
        }

        public ActionResult UpdateFeature(int id)
        {
            var value = context.Features.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateFeature(Feature model)
        {
            var value = context.Features.Find(model.FeatureId);
            value.Title = model.Title;
            value.Header = model.Header;
            value.ImageUrl = model.ImageUrl;
            value.Description = model.Description;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}