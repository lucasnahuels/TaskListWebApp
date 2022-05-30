using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using TaskListWebApp.Server.Database.Interfaces;
using TaskListWebApp.Server.Helpers;

namespace TaskListWebApp.Server
{
    public class Startup
    {
        private readonly ITaskRepository _taskRepository;
        public Startup(IConfiguration configuration, ITaskRepository taskRepository)
        {
            Configuration = configuration;
            this._taskRepository = taskRepository;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddRazorPages();
            //services.AddDbContext<ApplicationDbContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString(""));
            //});
            services.AddDatabaseContext(Configuration.GetConnectionString("Seed"));
            services.AddDomainServices();
            SetDataToDatabase();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }

        private void SetDataToDatabase()
        {
            //clean database
            var oldDataList = _taskRepository.GetAll();
            foreach (var item in oldDataList)
            {
                _taskRepository.Delete(item);
            }
            //fill database
            var urlResponse = UrlHelper.CallUrl();
            var taskListFromResponse = MapperHelper.MapResponseToTaskList(urlResponse);
            foreach (var item in taskListFromResponse)
            {
                _taskRepository.Add(item);
            }
        }
    }
}
