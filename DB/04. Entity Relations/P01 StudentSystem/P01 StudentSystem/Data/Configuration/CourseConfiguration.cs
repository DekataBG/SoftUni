﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode();

            builder.Property(c => c.Description)
                .IsRequired(false)
                .IsUnicode();

            builder.Property(c => c.StartDate)
                .IsRequired();

            builder.Property(c => c.EndDate)
                .IsRequired();

            builder.Property(c => c.Price)
                .IsRequired();
        }
    }
}
