using LearnerProject.Models;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class BannerController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var value = context.Banners.First();
            return View(value);
        }
        public ActionResult UpdateBanner(int id)
        {
            var value = context.Banners.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateBanner(Banner banner)
        {
            var value = context.Banners.Find(banner.BannerId);
            value.Title = banner.Title;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}