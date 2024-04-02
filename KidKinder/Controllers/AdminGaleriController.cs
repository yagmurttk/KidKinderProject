using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminGaleriController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            return View(context.Galleries.ToList());
        }
        public ActionResult CreateImage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateImage(Gallery model)
        {
            model.Status = false;
            context.Galleries.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ImageChangeStatusTrue(int id)
        {
            var value = context.Galleries.Find(id);
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ImageChangeStatusFalse(int id)
        {
            var value = context.Galleries.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveGallery(int id)
        {
            var value = context.Galleries.Find(id);
            context.Galleries.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateImage(int id)
        {
            var value = context.Galleries.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateImage(Gallery gallery)
        {
            var value = context.Galleries.Find(gallery.GalleryId);
            value.ImageUrl = gallery.ImageUrl;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}