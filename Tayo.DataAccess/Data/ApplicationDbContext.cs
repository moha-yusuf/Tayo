using Microsoft.EntityFrameworkCore;
using Tayo.Models;

namespace Tayo.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }

        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Shoes", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Jeans", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Shirts", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Collection>().HasData(
                new Collection { Id = 1, Name = "Mens", DisplayOrder = 8 },
                new Collection { Id = 2, Name = "Womens", DisplayOrder = 21 },
                new Collection { Id = 3, Name = "Kids", DisplayOrder = 9 }
                );
            modelBuilder.Entity<ProductSize>().HasData(
                new ProductSize { Id = 1, Name = "Small", DisplayOrder = 1, IsActive = true },
                new ProductSize { Id = 2, Name = "Medium", DisplayOrder = 2, IsActive = true }
                );
            modelBuilder.Entity<ProductColor>().HasData(
                new ProductColor { Id = 1, Name = "Black", DisplayOrder = 1, IsActive = true },
                new ProductColor { Id = 2, Name = "White", DisplayOrder = 2, IsActive = true }
                );
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)"); // 18 total digits, 2 after the decimal point

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Classic White T-Shirt",
                    Description = "A comfortable white t-shirt made from 100% cotton.",
                    ImageUrl = "",
                    Price = 19.99M,
                    IsAvailable = true,
                    DisplayOrder = 1,
                    CategoryId = 1,
                    CollectionId = 1,
                    ProductColorId = 1,
                    ProductSizeId = 2
                },
                new Product
                {
                    Id = 2,
                    Name = "Blue Denim Jacket",
                    Description = "A stylish blue denim jacket perfect for casual wear.",
                    ImageUrl = "",
                    Price = 49.99M,
                    IsAvailable = true,
                    DisplayOrder = 2,
                    CategoryId = 1,
                    CollectionId = 2,
                    ProductColorId = 2,
                    ProductSizeId = 3
                },
                new Product
                {
                    Id = 3,
                    Name = "Black Leather Boots",
                    Description = "Durable black leather boots for all-weather conditions.",
                    ImageUrl = "",
                    Price = 89.99M,
                    IsAvailable = true,
                    DisplayOrder = 3,
                    CategoryId = 2,
                    CollectionId = 3,
                    ProductColorId = 1,
                    ProductSizeId = 4
                },
                new Product
                {
                    Id = 4,
                    Name = "Red Cotton Dress",
                    Description = "A lightweight red cotton dress, perfect for summer outings.",
                    ImageUrl = "",
                    Price = 39.99M,
                    IsAvailable = true,
                    DisplayOrder = 4,
                    CategoryId = 1,
                    CollectionId = 1,
                    ProductColorId = 2,
                    ProductSizeId = 2
                },
                new Product
                {
                    Id = 5,
                    Name = "Brown Leather Belt",
                    Description = "A high-quality brown leather belt with a silver buckle.",
                    ImageUrl = "",
                    Price = 24.99M,
                    IsAvailable = true,
                    DisplayOrder = 5,
                    CategoryId = 3,
                    CollectionId = 2,
                    ProductColorId = 1,
                    ProductSizeId = 1
                }
            );
        }
    }
}
