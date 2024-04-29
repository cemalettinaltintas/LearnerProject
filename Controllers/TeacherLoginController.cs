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
    public class TeacherLoginController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: TeacherLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Teacher teacher)
        {
            var values = context.Teachers.FirstOrDefault(x => x.UserName == teacher.UserName && x.Password == teacher.Password);
            if (values == null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(values.NameSurname,false);
                Session["teacherName"] = values.NameSurname;
                return RedirectToAction("Index","TeacherCourse");
                    
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
    }
}