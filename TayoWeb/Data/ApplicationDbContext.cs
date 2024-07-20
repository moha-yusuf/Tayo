using Microsoft.EntityFrameworkCore;
using TayoWeb.Models;

namespace TayoWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}
