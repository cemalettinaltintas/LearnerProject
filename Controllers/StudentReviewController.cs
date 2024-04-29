using LearnerProject.Models;
using LearnerProject.Models.Entities;
using LearnerProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class StudentReviewController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: StudentReview
        public ActionResult Index()
        {
            var values = context.Reviews.ToList();
            return View(values);
        }
        public ActionResult AddStudentReview()
        {
            List<SelectListItem> courses = (from x in context.Courses.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CourseId.ToString()
                                             }).ToList();
            ViewBag.courses = courses;
            return View();
        }
        [HttpPost]
        public ActionResult AddStudentReview(Review review)
        {
            string nameSurname = Session["studentName"].ToString();
            var studentId = context.Students.Where(x => x.NameSurname == nameSurname).Select(x => x.StudentId).FirstOrDefault();
            review.StudentId = studentId;
            context.Reviews.Add(review);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteReview(int id)
        {
            var value = context.Reviews.Find(id);
            context.Reviews.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateReview(int id)
        {
            List<SelectListItem> courses = (from x in context.Courses.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CourseId.ToString()
                                            }).ToList();
            ViewBag.courses = courses;
            var value = context.Reviews.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateReview(Review review)
        {
            var value = context.Reviews.Find(review.ReviewId);

            string nameSurname = Session["studentName"].ToString();
            var studentId = context.Students.Where(x => x.NameSurname == nameSurname).Select(x => x.StudentId).FirstOrDefault();
            value.StudentId=studentId;
            value.CourseId=review.CourseId;
            value.Comment = review.Comment;
            value.ReviewValue=review.ReviewValue;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}