using LearnerProject.Models.Entities;
using LearnerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class FAQController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var values = context.FAQs.ToList();
            return View(values);
        }
        public ActionResult AddFAQ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddFAQ(FAQ faq)
        {
            context.FAQs.Add(faq);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteFAQ(int id)
        {
            var value = context.FAQs.Find(id);

            context.FAQs.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateFAQ(int id)
        {
            var value = context.FAQs.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateFAQ(FAQ faq)
        {
            var value = context.FAQs.Find(faq.FAQId);

            value.Question = faq.Question;
            value.Answer = faq.Answer;
            value.ImageUrl = faq.ImageUrl;
            value.Status = faq.Status;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}