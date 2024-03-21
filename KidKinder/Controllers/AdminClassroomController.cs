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
    public class AdminClassroomController : Controller
    {
            KidKinderContext context = new KidKinderContext();
            public ActionResult ClassroomList()
            {
                return View(context.ClassRooms.ToList());
            }
            public ActionResult CreateClassroom()
            {
                return View();
            }
            [HttpPost]
            public ActionResult CreateClassroom(CreateClassroomViewModel createClassroomViewModel)
            {
                if (!ModelState.IsValid)
                {
                    return View(createClassroomViewModel);
                }
                var value = new ClassRoom()
                {
                    Description = createClassroomViewModel.Description,
                    AgeOfKids = createClassroomViewModel.AgeOfKids,
                    TotalSeat = createClassroomViewModel.TotalSeats,
                    ClassTime = createClassroomViewModel.ClassTime,
                    ImageUrl = createClassroomViewModel.ImageUrl,
                    Price = createClassroomViewModel.Price,
                    Title = createClassroomViewModel.Title
                };
                context.ClassRooms.Add(value);
                context.SaveChanges();
                return RedirectToAction("ClassroomList");
            }
            public ActionResult RemoveClassroom(int id)
            {
                context.ClassRooms.Remove(context.ClassRooms.Find(id));
                context.SaveChanges();
                return RedirectToAction("ClassroomList");
            }
            public ActionResult UpdateClassroom(int id)
            {
                var value = context.ClassRooms.Find(id);
                var model = new UpdateClassroomViewModel()
                {
                    TotalSeats = value.TotalSeat,
                    AgeOfKids = value.AgeOfKids,
                    Title = value.Title,
                    Description = value.Description,
                    ClassTime = value.ClassTime,
                    Price = value.Price,
                    ImageUrl = value.ImageUrl,
                    ClassroomId = value.ClassRoomId,
                };
                return View(model);
            }
            [HttpPost]
            public ActionResult UpdateClassroom(UpdateClassroomViewModel model)
            {
                var value = context.ClassRooms.Find(model.ClassroomId);
                value.ClassTime = model.ClassTime;
                value.Description = model.Description;
                value.AgeOfKids = model.AgeOfKids;
                value.ImageUrl = model.ImageUrl;
                value.Title = model.Title;
                value.Price = model.Price;
                value.TotalSeat = model.TotalSeats;
                context.SaveChanges();
                return RedirectToAction("ClassroomList");
            }
        }
    }