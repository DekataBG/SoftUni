using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(s => s.PhoneNumber)
                .IsRequired(false)
                .HasMaxLength(10)
                .IsFixedLength()
                .IsUnicode(false);

            builder.Property(s => s.RegisteredOn)
                .IsRequired();

            builder.Property(s => s.Birthday)
               .IsRequired(false);
            
        }
    }
}
