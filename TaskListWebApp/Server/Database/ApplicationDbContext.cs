using Microsoft.EntityFrameworkCore;
using TaskListWebApp.Shared.Models;

namespace TaskListWebApp.Server.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<TaskModel> Tasks { get; set; }
    }
}
