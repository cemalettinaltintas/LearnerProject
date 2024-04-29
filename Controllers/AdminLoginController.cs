using LearnerProject.Models;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LearnerProject.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var value=context.Admins.FirstOrDefault(x=>x.UserName==admin.UserName && x.Password==admin.Password);
            if (value==null)
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(value.NameSurname, false);
                Session["adminName"] = value.NameSurname;
                return RedirectToAction("Index", "AdminCourse");
            }
        }
    }
}