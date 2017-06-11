using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Sollicitatiebeheer.Web.Startup {
    public class Startup {
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<Startup> _logger;
        private readonly IHostingEnvironment _environment;

        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory) {
            _loggerFactory = loggerFactory;
            _environment = env;

            _logger = _loggerFactory.CreateLogger<Startup>();

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables("SOLLICITATIEBEHEER_");
            Configuration = builder.Build();

            var connectionString = Configuration.GetConnectionString("Sollicitatiebeheer");
            _logger.LogInformation($"Working with connection string '{connectionString}'.");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services) {
            // Add framework services.
            services.AddMvc()
                    .AddFeatureFolders()
                    .AddAndConfigureFluentValidation()
                    .AddAndConfigureFilters(_loggerFactory);

            // Add application services.
            services.AddAndConfigureMediatR();

            // Configure autofac DI and return the service provider to ASP.NET Core
            return services.AddAndConfigureAutofac();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            } else {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();
        }
    }
}
