using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePub.Configurations.Startup
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
