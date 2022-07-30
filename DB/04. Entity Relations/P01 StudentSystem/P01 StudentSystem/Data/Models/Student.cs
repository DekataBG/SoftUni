using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            Homeworks = new HashSet<Homework>();
            StudentCourses = new HashSet<StudentCourse>();
            CourseEnrollments = new HashSet<StudentCourse>();
            HomeworkSubmissions = new HashSet<Homework>();
        }

        public int StudentId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegisteredOn { get; set; }
        public DateTime? Birthday { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        [NotMapped]
        public virtual ICollection<Homework> HomeworkSubmissions { get; set; }

        public virtual ICollection<StudentCourse> StudentCourses { get; set; }

        [NotMapped]
        public virtual ICollection<StudentCourse> CourseEnrollments { get; set; }
    }
}
