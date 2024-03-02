using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [AllowAnonymous]
    public class BookASeatController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult BookASeatPartial()
        {
            var values = context.BookASeats.ToList();
            return PartialView(values);
        }
        public PartialViewResult BookASeat2Partial()
        {
            ViewBag.ClassRoom = new SelectList(context.ClassRooms.ToList(), "ClassRoomId", "Title");
            var classRoom = context.ClassRooms.ToList();
            return PartialView();
        }
        public PartialViewResult BookASeatHeaderPartial()
        {
            return PartialView();
        }
    }
}