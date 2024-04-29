using LearnerProject.Models;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnerProject.Controllers
{
    [AllowAnonymous]
    public class StudentLoginController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: StudentLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Student student)
        {
            var value = context.Students.FirstOrDefault(x => x.UserName == student.UserName && x.Password == student.Password);

            if (value == null)
            {
                ModelState.AddModelError("", "Kullanıcı adı hatalı");
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(value.NameSurname, false);
                Session["studentName"] = value.NameSurname;
                //Session["studentId"] = value.StudentId;
                return RedirectToAction("Index", "StudentCourse");
            }
        }
    }
}