using KidKinder.Context;
using KidKinder.Entities;
using KidKinder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ContactHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult ContactAdressPartial()
        {
            ViewBag.description = context.Communications.Select(x => x.Description).FirstOrDefault();
            ViewBag.phone = context.Communications.Select(x => x.Phone).FirstOrDefault();
            ViewBag.adress = context.Communications.Select(x => x.Address).FirstOrDefault();
            ViewBag.email = context.Communications.Select(x => x.Email).FirstOrDefault();
            return PartialView();
        }
        public PartialViewResult ContactMessagePartial()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SendMessage(SendMessageViewModel contact)
        {
            if (ModelState.IsValid)
            {
                var value = new Contact()
                {
                    Email = contact.Email,
                    IsRead = false,
                    Message = contact.Email,
                    NameSurname = contact.NameSurname,
                    SendDate = DateTime.Now,
                    Subject = contact.Subject
                };
                context.Contacts.Add(value);
                context.SaveChanges();
                return RedirectToAction("Index", "Default");
            }
            else
            {
                return RedirectToAction("Index", "Contact");
            }
        }
    }
}