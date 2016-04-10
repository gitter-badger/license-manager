using AutoMapper;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LicenseManager.Configuration;
using LicenseManager.Configuration.Mappings;
using LicenseManager.Database;

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
                .AddDbContext<LicenseManagerDbContext>(options => options.UseSqlServer(connectionString));

            services
                .AddMvc();

            services
                .AddOptions();

            services
                .Configure<GlobalSettings>(Configuration.GetSection("GlobalSettings"));

            services
                .AddSingleton<IMapper>(sc => CreateMapperConfiguration().CreateMapper());
        }

        private MapperConfiguration CreateMapperConfiguration()
        {
            MapperConfiguration mapperConfiguration = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile(new AutoMapperProfile());
            });

            mapperConfiguration.AssertConfigurationIsValid();

            return mapperConfiguration;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

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