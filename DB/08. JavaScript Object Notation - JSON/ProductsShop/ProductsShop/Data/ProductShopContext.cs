using Microsoft.EntityFrameworkCore;
using ProductsShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsShop.Data
{
    public class ProductShopContext : DbContext
    {
        public ProductShopContext() { }

        public ProductShopContext(DbContextOptions<ProductShopContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryProducts> CategoryProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Config.GetConnectionString());
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryProducts>()
                .HasKey(cp => new { cp.CategoryId, cp.ProductId });

            base.OnModelCreating(modelBuilder);
        }
    }
}
