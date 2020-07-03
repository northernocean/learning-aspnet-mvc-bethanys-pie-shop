using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models.SeedData
{
    public static class SeedCategories
    {

        public static void Seed(ModelBuilder modelBuilder)
        {
            //seed categories
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 1, CategoryName = "Fruit pies" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 2, CategoryName = "Cheese cakes" });
            modelBuilder.Entity<Category>().HasData(new Category { CategoryId = 3, CategoryName = "Seasonal pies" });
        }

    }
}
