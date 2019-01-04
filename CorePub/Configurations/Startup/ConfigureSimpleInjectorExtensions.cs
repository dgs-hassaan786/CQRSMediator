using CorePub.Foundation.ConfigurationProvider;
using CorePub.Repositories.Articles.IProviders;
using CorePub.Repositories.Articles.Queries;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using System.Collections.Generic;
using System.Reflection;

namespace CorePub.Configurations.Startup
{
    public partial class ConfigurationExtensions
    {
        public static void ConfigureSimpleInjector(this IServiceCollection services, Container container, IConfiguration configuration)
        {
            // Default lifestyle scoped +async
            // The recommendation is to use AsyncScopedLifestyle in for applications that solely consist of a Web API(or other asynchronous technologies such as ASP.NET Core)
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Register controllers DI resolution
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));

            //Register views DI resolution
            services.AddSingleton<IViewComponentActivator>(new SimpleInjectorViewComponentActivator(container));

            // or register MailSettings as singleton in the container.
            AppSettings appSettings = configuration.Get<AppSettings>();
            container.RegisterInstance(appSettings);

            //Enable CrossWiring in the application
            services.EnableSimpleInjectorCrossWiring(container);

            // Wrap AspNet requests into Simpleinjector's scoped lifestyle
            services.UseSimpleInjectorAspNetRequestScoping(container);
            
            services.AddTransient<IArticleService, ArticleService>();
        }


        public static IApplicationBuilder InjectSimpleInjectorDependecy(this IApplicationBuilder app, Container container)
        {
            var assemblies = GetAssemblies();

            container.RegisterMvcControllers(app);
            container.RegisterMvcViewComponents(app);

            // Allow Simple Injector to resolve services from ASP.NET Core.
            container.AutoCrossWireAspNetComponents(app);
            
            //container.RegisterSingleton<IMediator, Mediator>();
            //container.Register(typeof(IRequestHandler<,>), typeof(CorePub.Startup).GetType().Assembly);

            // Register services
            //container.Register<IArticleService, ArticleService>(Lifestyle.Scoped); // lifestyle can set here, sometimes you want to change the default lifestyle like singleton exeptionally

            
            // Verify Simple Injector configuration
            container.Verify();

            return app;
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(IMediator).GetTypeInfo().Assembly;
            yield return typeof(CorePub.Repositories.Articles.Queries.GetAllArticlesQuery).GetTypeInfo().Assembly;
        }
    }
}
