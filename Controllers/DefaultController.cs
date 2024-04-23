using LearnerProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
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
            var values = context.Courses.Include(x => x.Reviews).OrderByDescending(x => x.CourseId).Take(3).ToList();
            return PartialView(values);
        }
        public ActionResult CourseDetail(int id)
        {
            var value = context.Courses.Find(id);

            var reviewList=context.Reviews.Where(x=>x.CourseId==id).ToList();
            ViewBag.reviewList = reviewList;
            return View(value);
        }
    }
}