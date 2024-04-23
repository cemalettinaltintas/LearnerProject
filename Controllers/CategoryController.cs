using LearnerProject.Models;
using LearnerProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnerProject.Controllers
{
    public class CategoryController : Controller
    {
        LearnerContext context = new LearnerContext();
        // GET: Category
        public ActionResult Index()
        {
            var values=context.Categories.Where(c=>c.Status==true).ToList();
            return View(values);
        }
        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            category.Status = true;
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Categories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            value.Icon = category.Icon;
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}