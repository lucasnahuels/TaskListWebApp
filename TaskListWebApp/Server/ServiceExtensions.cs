using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TaskListWebApp.Server.Database;
using TaskListWebApp.Server.Database.Interfaces;

namespace TaskListWebApp.Server
{
    public static class ServiceExtensions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
        }

        public static void AddDatabaseContext(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
