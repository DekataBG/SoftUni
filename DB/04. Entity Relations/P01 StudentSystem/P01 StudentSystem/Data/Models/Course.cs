using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            Resources = new HashSet<Resource>();
            Homeworks = new HashSet<Homework>();
            HomeworkSubmissions = new HashSet<Homework>();
            StudentCourses = new HashSet<StudentCourse>();
            StudentsEnrolled = new HashSet<StudentCourse>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }       
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Resource> Resources { get; set; }

        [NotMapped]
        public virtual ICollection<Homework> Homeworks { get; set; }
        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

        [NotMapped]
        public virtual ICollection<StudentCourse> StudentsEnrolled { get; set; }


    }
}
