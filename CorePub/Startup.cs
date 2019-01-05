using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePub.Configurations.Startup;
using CorePub.Foundation.ConfigurationProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleInjector;

namespace CorePub
{
    public class Startup
    {
        private Container _container = new Container();
        private IConfiguration _configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath)
                .AddJsonFile("appSettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {         
            services.ConfigureMvc();            
            services.ConfigureSimpleInjector(_container, _configuration);
            services.ConfigureMedaitR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            app.ConfigureEnvironment(env);
            app.ConfigureRouting();
            app.InjectSimpleInjectorDependecy(_container);

            loggerFactory.ConfigureSerilog();
        }
    }
}
