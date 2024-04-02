using KidKinder.Context;
using KidKinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KidKinder.Controllers
{
    public class AdminTeacherController : Controller
    {
        KidKinderContext context = new KidKinderContext();
        public ActionResult AdminTeacherList()
        {
            var values = context.Teachers.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateTeacher()
        {
            ViewBag.teacherBranch = new SelectList(context.Branches.ToList(), "BranchId", "Name");
            return View();
        }
        [HttpPost]
        public ActionResult CreateTeacher(Teacher teacher)
        {
            context.Teachers.Add(teacher);
            context.SaveChanges();
            return RedirectToAction("AdminTeacherList");
        }
        public ActionResult DeleteTeacher(int id)
        {
            var value = context.Teachers.Find(id);
            context.Teachers.Remove(value);
            context.SaveChanges();
            return RedirectToAction("AdminTeacherList");
        }
        [HttpGet]
        public ActionResult UpdateTeacher(int id)
        {
            ViewBag.teacherBranch = new SelectList(context.Branches.ToList(), "BranchId", "Name");
            var value = context.Teachers.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTeacher(Teacher teacher)
        {
            var value = context.Teachers.Find(teacher.TeacherId);
            value.ImageUrl = teacher.ImageUrl;
            value.NameSurname = teacher.NameSurname;
            value.BranchId = teacher.BranchId;
            context.SaveChanges();
            return RedirectToAction("AdminTeacherList");
        }
    }
}