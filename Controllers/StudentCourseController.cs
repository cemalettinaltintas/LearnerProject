using LearnerProject.Models;
using LearnerProject.Settings;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class StudentCourseController : Controller
    {
        LearnerContext context=new LearnerContext();
        // GET: StudentCourse
        public ActionResult Index(int sayfa=1)
        {
            string studentName = Session["studentName"].ToString();
            var student = context.Students.Where(x => x.NameSurname ==studentName ).Select(x => x.StudentId).FirstOrDefault();
            var values = context.CourseRegisters.Where(x => x.StudentId == student).ToList().ToPagedList(sayfa,5);

            return View(values);
        }
        public ActionResult MyCourseList(int id)
        {
            var values = context.CourseVideos.Where(x=>x.Course.CourseId==id).ToList();
            return View(values);
        }
    }
}