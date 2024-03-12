using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminNotificationController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.Notifications.OrderByDescending(x => x.NotificationDate).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateNotification()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateNotification(Notification model)
        {
            context.Notifications.Add(model);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult RemoveNotification(int id)
        {
            var value = context.Notifications.Find(id);
            context.Notifications.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateNotification(int id)
        {
            var value = context.Notifications.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateNotification(Notification model)
        {
            var value = context.Notifications.Find(model.NotificationId);
            value.Title = model.Title;
            value.ImageUrl = model.ImageUrl;
            value.Description = model.Description;
            value.NotificationDate = model.NotificationDate;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}