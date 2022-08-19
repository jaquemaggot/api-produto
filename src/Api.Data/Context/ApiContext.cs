using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class ApiContext : DbContext
    {
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductCategoryEntity> ProductsCategories { get; set; }


        public ApiContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductEntity>(new ProductMap().Configure);
            modelBuilder.Entity<CategoryEntity>(new CategoryMap().Configure);
            modelBuilder.Entity<ProductCategoryEntity>(new ProductCategoryMap().Configure);


            modelBuilder.Entity<ProductCategoryEntity>().HasOne<ProductEntity>(e => e.Product).WithMany(e => e.ProductCategory).HasForeignKey(e => e.IdProduct);
            modelBuilder.Entity<ProductCategoryEntity>().HasOne<CategoryEntity>(e => e.Category).WithMany(e => e.ProductCategory).HasForeignKey(e => e.IdCategory);
        }
    }
}
