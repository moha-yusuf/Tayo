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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Shoes", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Jeans", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Kids", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Collection>().HasData(
                new Collection { Id = 1, Name = "Mens", DisplayOrder = 8 },
                new Collection { Id = 2, Name = "Womens", DisplayOrder = 21 },
                new Collection { Id = 3, Name = "Kids", DisplayOrder = 9 }
                );
        }
    }
}
