using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnerProject.Models.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public List<Review> Reviews { get; set; }

        public List<CourseRegister> CourseRegisters { get; set; }
        public List<CourseVideo> CourseVideos { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }

    }
}