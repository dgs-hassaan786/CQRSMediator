using CorePub.Foundation.ConfigurationProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CorePub.Configurations.Shared.Startup
{
    public partial class ConfigurationExtensions
    {
        public static IApplicationBuilder InjectSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Core Pub API");
            });

            return app;
        }

        public static IServiceCollection ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
        {
            AppSettings appSettings = configuration.Get<AppSettings>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "Core Pub API",
                    Version = appSettings.ApplicationSettings.Version.ToString()
                });
            });

            return services;
        }
    }
}
