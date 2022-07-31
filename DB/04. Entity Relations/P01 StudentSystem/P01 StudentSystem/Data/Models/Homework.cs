using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        public int HomeworkId { get; set; }
        public string Content { get; set; }
        public ContentType ContentType { get; set; }
        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}
