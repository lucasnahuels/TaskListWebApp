using Microsoft.EntityFrameworkCore;
using TaskListWebApp.Server.Helpers;
using TaskListWebApp.Shared.Models;

namespace TaskListWebApp.Server.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>()
                .ToTable("Tasks");

            modelBuilder.Entity<ToDoTask>()
                .Property(t => t.Id)
                .UseIdentityColumn();
            
            modelBuilder.Entity<ToDoTask>()
                .Property(t => t.Title)
                .IsRequired(true);
            
            modelBuilder.Entity<ToDoTask>()
                .Property(t => t.Done)
                .HasDefaultValue(false);
        }
        public DbSet<ToDoTask> Tasks { get; set; }
    }
}
