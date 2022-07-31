using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Configuration;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext() { }

        public StudentSystemContext(DbContextOptions<StudentSystemContext> dbContextOptions) 
            : base(dbContextOptions) { }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Homework> HomeworkSubmissions { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString.GetConnectionString());
            }

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  -1st way

            //2nd(safer) way
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new CourseConfiguration());
            modelBuilder.ApplyConfiguration(new ResourceConfiguration());
            modelBuilder.ApplyConfiguration(new StudentCourseConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
