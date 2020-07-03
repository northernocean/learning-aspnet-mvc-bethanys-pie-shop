﻿using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Pie> Pies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData.SeedPies.Seed(modelBuilder);
            SeedData.SeedCategories.Seed(modelBuilder);

        }

    }
}