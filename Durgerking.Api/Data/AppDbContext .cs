using Durgerking.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Durgerking.Api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
    }
}
