using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CorePub.Configurations.Shared.Startup
{
    public partial class ConfigurationExtensions
    {
        public static IServiceCollection ConfigureMedaitR(this IServiceCollection services)
        {
            services.AddMediatR();
            //services.AddMediatR(typeof(CorePub.Startup).GetType().Assembly);
            //services.AddMediatR(typeof(CorePub.Repositories.Articles.Queries.GetAllArticlesQuery).GetType().Assembly);            
            return services;
        }
    }
}
