using LearnerProject.Models;
using LearnerProject.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    [SessionTimeOut]
    public class TeacherCourseVideoController : Controller
    {
        LearnerContext context=new LearnerContext();

        // GET: TeacherCourseVideo
        public ActionResult Index()
        {
            string teacherNameSurname = Session["teacherName"].ToString();
            var teacher=context.Teachers.Where(x=>x.NameSurname==teacherNameSurname).FirstOrDefault();
            var teacherCourses = context.Courses.Where(x => x.TeacherId ==teacher.TeacherId).Select(x=>x.CourseId).ToList();

            var teacherVideos=context.CourseVideos.Where(x=>teacherCourses.Contains(x.CourseId)==true).ToList();

            return View(teacherVideos);
        }
    }
}