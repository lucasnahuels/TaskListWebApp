using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TaskListWebApp.Server.Database;
using TaskListWebApp.Server.Database.Interfaces;
using TaskListWebApp.Server.Helpers;
using TaskListWebApp.Server.Services;

namespace TaskListWebApp.Server
{
    public static class ServiceExtensions
    {
        public static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskService, TaskService>();
        }

        public static void AddDatabaseContext(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork<ApplicationDbContext>>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        }

        public static  IHost SeedData(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            context.Database.EnsureCreated();
            context.Database.Migrate();

            var taskListFromResponse = GetUrlHelper.GetResponseAsync().Result;

            context.Tasks.AddRange(taskListFromResponse);
            context.SaveChanges();

            return host;
        }
    }
}
