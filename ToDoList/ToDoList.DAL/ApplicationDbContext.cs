using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entites;

namespace ToDoList.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ToDoListItem> ToDoListItems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
