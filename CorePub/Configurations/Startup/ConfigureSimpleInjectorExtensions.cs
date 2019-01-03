using CorePub.Repositories.Articles.IProviders;
using CorePub.Repositories.Articles.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorePub.Configurations.Startup
{
    public partial class ConfigurationExtensions
    {
        public static void ConfigureSimpleInjector(this IServiceCollection services, Container container)
        {
            // Default lifestyle scoped +async
            // The recommendation is to use AsyncScopedLifestyle in for applications that solely consist of a Web API(or other asynchronous technologies such as ASP.NET Core)
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register services
            container.Register<IGetArticle, ArticleReadingService>(Lifestyle.Scoped); // lifestyle can set here, sometimes you want to change the default lifestyle like singleton exeptionally

            // Register controllers DI resolution
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));

            // Wrap AspNet requests into Simpleinjector's scoped lifestyle
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }


        public static IApplicationBuilder InjectSimpleInjectorDependecy(this IApplicationBuilder app, Container container)
        {
            container.RegisterMvcControllers(app);

            // Verify Simple Injector configuration
            container.Verify();

            return app;
        }
    }
}
