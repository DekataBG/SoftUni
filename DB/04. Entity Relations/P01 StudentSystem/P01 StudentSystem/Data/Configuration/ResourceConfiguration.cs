using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P01_StudentSystem.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentSystem.Data.Configuration
{
    public class ResourceConfiguration : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(r => r.ResourceId);

            builder
                .HasOne(r => r.Course)
                .WithMany(c => c.Resources)
                .HasForeignKey(r => r.CourseId);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode();

            builder.Property(r => r.Url)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(r => r.ResourceType)
                .IsRequired();

            builder.Property(r => r.CourseId)
                .IsRequired();
        }
    }
}
