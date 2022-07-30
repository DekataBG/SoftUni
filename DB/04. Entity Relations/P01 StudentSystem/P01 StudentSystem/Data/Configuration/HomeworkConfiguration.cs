using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data.Configuration
{
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(h => h.HomeworkId);

            builder
                .HasOne(h => h.Student)
                .WithMany(s => s.Homeworks)
                .HasForeignKey(h => h.StudentId);

            builder
                .HasOne(h => h.Course)
                .WithMany(s => s.Homeworks)
                .HasForeignKey(h => h.CourseId);

            builder.Property(c => c.Content)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false);

            builder.Property(c => c.ContentType)
                .IsRequired();

            builder.Property(c => c.SubmissionTime)
                .IsRequired();

            builder.Property(c => c.Student)
                .IsRequired();

            builder.Property(c => c.StudentId)
                .IsRequired();

            builder.Property(c => c.Course)
                .IsRequired();

            builder.Property(c => c.CourseId)
                .IsRequired();
        }
    }
}
