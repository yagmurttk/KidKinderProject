using KidKinder.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{

    public class AdminDashboardController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult Index()
        {
            ViewBag.ResimCizmeCount = context.Teachers.Where(x => x.BranchId == context.Branches.Where(z => z.Name == "Resim Çizim").Select(y => y.BranchId).FirstOrDefault()).Count();

            ViewBag.AvgPrice = context.ClassRooms.Average(x => x.Price).ToString("0.00");

            ViewBag.TotalService = context.Services.Count();
            var values = context.Teachers.GroupBy(x => x.BranchId).Select(x => new
            {
                Key = x.Key,
                Count = x.Count()
            }).OrderByDescending(x => x.Count).FirstOrDefault();

            ViewBag.MaxBranch = context.Branches.Where(x => x.BranchId == values.Key).Select(x => x.Name).FirstOrDefault();
            var maxbranch = context.Branches.Where(x => x.BranchId == values.Key).Select(x => x.Name).FirstOrDefault();
            ViewBag.MaxBranchTeacher = context.Teachers.Where(x => x.BranchId == (context.Branches.Where(y => y.Name == maxbranch.ToString()).Select(y => y.BranchId).FirstOrDefault())).Count();
            ViewBag.TotalBranch = context.Branches.Count();
            ViewBag.LastClassroom = context.ClassRooms.OrderByDescending(x => x.ClassRoomId).Select(x => x.Title).FirstOrDefault();
            ViewBag.TotalMessage = context.Contacts.Count();
            ViewBag.AdminCount = context.Admins.Count();
            ViewBag.RezCount = context.BookASeats.Count();
            return View();
        }
        public PartialViewResult _DashboardTeacherPartial()
        {

            return PartialView(context.Teachers.ToList());
        }
        public PartialViewResult _DashboardClassroomPartial()
        {

            return PartialView(context.ClassRooms.ToList());
        }
    }
}