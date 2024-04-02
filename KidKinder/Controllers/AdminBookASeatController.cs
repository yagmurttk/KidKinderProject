using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminBookASeatController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            var values = context.BookASeats.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateBookASeat()
        {
            ViewBag.BookASeat = new SelectList(context.ClassRooms.ToList(), "ClassRoomId", "Title");
            return View();
        }
        [HttpPost]
        public ActionResult CreateBookASeat(BookASeat bookASeat)
        {
            context.BookASeats.Add(bookASeat);
            context.SaveChanges();
            return RedirectToAction("AdminBookASeat");
        }
        public ActionResult DeleteBookASeat(int id)
        {
            var value = context.BookASeats.Find(id);
            context.BookASeats.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AdminBookASeat");
        }
        [HttpGet]
        public ActionResult UpdateBookASeat(int id)
        {
            ViewBag.BookASeat = new SelectList(context.ClassRooms.ToList(), "ClassRoomId", "Title");
            var value = context.Teachers.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateBookASeat(BookASeat bookASeat)
        {
            var value = context.BookASeats.Find(bookASeat.BookASeatId);
            value.BookASeatId = bookASeat.BookASeatId;
            value.Title = bookASeat.Title;
            value.Name = bookASeat.Name;
            value.Mail = bookASeat.Mail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}