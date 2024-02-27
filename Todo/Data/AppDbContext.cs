using Microsoft.EntityFrameworkCore;
using Todo.entity;

namespace Todo.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoModel> Todos { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TodoModel>()
                .HasKey(x => x.Id);

            builder.Entity<TodoModel>()
                .Property(x => x.Id)
                .HasMaxLength(50)
                .IsRequired();

            builder.Entity<TodoModel>()
                .Property(x => x.Description)
                .HasMaxLength(250);


            base.OnModelCreating(builder);
        }
    }
}
