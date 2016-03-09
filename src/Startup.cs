using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LicenseManager.Models;
using LicenseManager.Configuration;

namespace LicenseManager
{
    public class Startup
    {
        /// Konfiguracja
        public IConfigurationRoot Configuration { get; set; }

        public Startup(IHostingEnvironment env)
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            Configuration = configurationBuilder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration["Data:DefaultConnection:ConnectionString"];

            services
                .AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

            services
                .AddMvc();

            services
                .AddOptions();

            services
                .Configure<GlobalSettings>(Configuration.GetSection("GlobalSettings"));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "Home",
                    template: "{controller=Home}/{action=Index}"
                );
            });
        }

        public static void Main(string[] args) => Microsoft.AspNet.Hosting.WebApplication.Run<Startup>(args);
    }
}