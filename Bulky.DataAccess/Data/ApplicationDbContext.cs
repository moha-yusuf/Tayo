using Microsoft.EntityFrameworkCore;
using Bulky.Models;

namespace Bulky.DataAccess.Data
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
        }
    }
}
