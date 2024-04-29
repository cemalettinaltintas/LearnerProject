using LearnerProject.Models.Entities;
using LearnerProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace LearnerProject.Controllers
{
    public class TestimonialController : Controller
    {
        LearnerContext context = new LearnerContext();
        public ActionResult Index()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }
        public ActionResult AddTestimonial()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(Testimonial  testimonial)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/Testimonial/" + dosyaadi + uzanti;
                //Resmi klasörün içine atalım.
                Request.Files[0].SaveAs(Server.MapPath(yol));

                testimonial.ImageUrl = "/Image/Testimonial/" + dosyaadi + uzanti;
            }
            context.Testimonials.Add(testimonial);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);

            if (System.IO.File.Exists(Server.MapPath(value.ImageUrl)))
            {
                System.IO.File.Delete(Server.MapPath(value.ImageUrl));
            }

            context.Testimonials.Remove(value);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var value = context.Testimonials.Find(testimonial.TestimonialId);

            if (testimonial.ImageUrl != null)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/Testimonial/" + dosyaadi + uzanti;
                //Resmi klasörün içine atalım.
                Request.Files[0].SaveAs(Server.MapPath(yol));

                if (System.IO.File.Exists(Server.MapPath(value.ImageUrl)))
                {
                    System.IO.File.Delete(Server.MapPath(value.ImageUrl));
                }

                value.ImageUrl = "/Image/Testimonial/" + dosyaadi + uzanti;
            }

            value.NameSurname = testimonial.NameSurname;
            value.Title = testimonial.Title;
            value.Comment=testimonial.Comment;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}