using CorePub.Configurations.Shared.Startup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleInjector;

namespace CorePub.Services
{
    public class Startup
    {
        private Container _container = new Container();
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration => _configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureMvc(_configuration);
            services.ConfigureSimpleInjector(_container, _configuration);
            services.ConfigureMedaitR();
            services.ConfigureSwagger(_configuration);
            services.ConfigureCouchBase(_configuration);
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime applicationLifetime)
        {
            app.ConfigureEnvironment(env);
            app.ConfigureWebApiRouting();
            app.InjectSimpleInjectorDependecy(_container);
            loggerFactory.ConfigureSerilog();
            app.InjectSwagger();
            app.ClearCouchBaseResources(applicationLifetime);
        }

       
    }
}
