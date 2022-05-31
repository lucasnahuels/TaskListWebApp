using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using TaskListWebApp.Server.Database;
using TaskListWebApp.Server.Database.Interfaces;
using TaskListWebApp.Server.Helpers;

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

        public static async Task<IHost> SeedDataAsync(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            context.Database.Migrate();
            var taskListFromResponse = await GetUrlHelper.GetResponseAsync();
            context.Tasks.AddRange(taskListFromResponse);
            context.SaveChanges();

            return host;
        }
    }
}
