using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    [AllowAnonymous]
    public class ClassRoomController : Controller
    {        
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult ClassRoomPartial()
        {
            var values = context.ClassRooms.ToList();
            return PartialView(values);
        }
        public PartialViewResult ClassRoomHeaderPartial()
        {
            return PartialView();
        }
    }
}