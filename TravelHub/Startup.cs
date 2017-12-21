using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TravelHub.Common.ConfigurationService;
using TravelHub.MailService;
using TravelHub.services.FlightService.Implementation;
using TravelHub.services.FlightService.Interfaces;
using TravelHub.services.NewsService.Implementation;
using TravelHub.Sql.Data;

namespace TravelHub.Web
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _config;
        public Startup(IConfiguration configuration,IHostingEnvironment env)
        {
            _env = env;
            var builder=new ConfigurationBuilder().SetBasePath(_env.ContentRootPath)
                .AddJsonFile("config.json")
                .AddEnvironmentVariables();
            _config = builder.Build();

        }

        public IConfiguration Configuration => _config;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(_config);
            services.AddMvc();
            if (_env.IsDevelopment())
            {
                services.AddScoped<IMailService, DebugMailService>();
            }
            else
            {
                //implement a real mail service
            }
            RegisterAllServices(services);

            //add database context
            services.AddDbContext<TravelHubContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory factory)
        {

            //initialize automapper
            //Mapper.Initialize(config =>
            //{
            //    config.CreateMap<>()
            //});
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
                factory.AddDebug(LogLevel.Information);
            }
            else
            {
                factory.AddDebug(LogLevel.Error);
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                    
            });
        }

        public void RegisterAllServices(IServiceCollection services)
        {
            services.AddTransient<IFlightSearchService,FlightSearchService>();
            services.AddSingleton<IHttpSocketService, HttpSocketService>();
            services.AddTransient<INewsApiService, NewsApiService>();
        }
    }
}
