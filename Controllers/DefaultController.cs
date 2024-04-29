using LearnerProject.Models;
using LearnerProject.Models.Entities;
using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult DefaultCoursePartial()
        {
            var values = context.Courses.Include(x => x.Reviews).OrderByDescending(x => x.CourseId).Take(3).Include(x => x.CourseVideos).ToList();
            return PartialView(values);
        }
        public ActionResult CourseDetail(int id)
        {
            var value = context.Courses.Find(id);

            var reviewList = context.Reviews.Where(x => x.CourseId == id).ToList();
            ViewBag.reviewList = reviewList;
            return View(value);
        }

        public PartialViewResult DefaultCategoryPartial()
        {
            var categories = context.Categories.Include(x => x.Courses).ToList();

            return PartialView(categories);
        }
        public PartialViewResult DefaultClassroomPartial()
        {
            var classrooms = context.Classrooms.ToList();
            return PartialView(classrooms);
        }

        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultAboutPartial()
        {
            var value = context.Abouts.Find(1);
            ViewBag.studentCount = context.Students.Count();
            ViewBag.teacherCount = context.Teachers.Count();
            return PartialView(value);
        }
        public PartialViewResult DefaultBannerPartial()
        {
            var value = context.Banners.Select(x=>x.Title).FirstOrDefault();
            ViewBag.value = value;
            return PartialView();
        }

        public PartialViewResult DefaultFAQsPartial()
        {
            var values = context.FAQs.ToList();
            return PartialView(values);
        }
        public ActionResult GetAllCourses(int sayfa = 1)
        {
            var courses = context.Courses.Include(x => x.Reviews).OrderByDescending(x => x.CourseId).Include(x => x.CourseVideos).ToList().ToPagedList(sayfa, 6);
            return View(courses);
        }

        public ActionResult DefaultContact()
        {
            var value = context.Contacts.First();
            ViewBag.address = value.Address;
            ViewBag.email = value.Email;
            ViewBag.phone = value.Phone;
            ViewBag.openHours = value.OpenHours;
            return View();
        }
        [HttpPost]
        public ActionResult DefaultSendMessage(Message message)
        {
            message.IsRead = false;
            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DefaultSSS()
        {
            var values = context.FAQs.ToList();
            return View(values);
        }
    }
}