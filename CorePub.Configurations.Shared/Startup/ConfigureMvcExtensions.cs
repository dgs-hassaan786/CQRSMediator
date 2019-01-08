using CorePub.Configurations.Shared.Formatters;
using CorePub.Foundation.ConfigurationProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CorePub.Configurations.Shared.Startup
{
    public static partial class ConfigurationExtensions
    {
        /// <summary>
        /// This extension is used for adding the MVC functionality in the application
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection ConfigureMvc(this IServiceCollection services, IConfiguration configuration)
        {
            //So we have added the MVC in the pipeline along with the options                        
            services.AddMvc(options =>
            {
                //We are globally setting the AutoValidateAntiforgeryTokenAttribute at the runtime
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());

                AppSettings appSettings = configuration.Get<AppSettings>();

                if (appSettings.ApplicationSettings.IsPascalCaseFormattingToUse)
                {
                    options.OutputFormatters.Add(new PascalCaseFormatter());
                }

            })

            //We are adding the Localization based on the language globally 
            //via AddViewLocalization() extension
            //for further understanding check out the article 
            //https://andrewlock.net/adding-localisation-to-an-asp-net-core-application/
            .AddViewLocalization()

            //Similarly we can add localization in the Data annotation 
            //via AddDataAnnotationsLocalization() extension
            .AddDataAnnotationsLocalization()

            //Inorder to configure the compatibility with the version of mvc
            //we use the SetCompatibilityVersion() extension
            //It is available in the package Microsoft.AspNetCore.Mvc.Formatters.Xml
            //For installation check: https://stackoverflow.com/questions/48546997/how-to-fix-imvcbuilder-doesnt-contain-a-definition-for-addxmldatacontractser
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            return services;
        }

        /// <summary>
        /// This extension is used for adding the routing functionality in the MVC application
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder ConfigureRouting(this IApplicationBuilder app)
        {
            app.UseStaticFiles();

            //Uncomment this line of code if you wish to use the MVC with the default routing
            //app.UseMvcWithDefaultRoute();

            app.UseMvc(routeConfig =>
            {
                routeConfig.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
            return app;
        }


        /// <summary>
        /// This extension is used for adding the routing functionality in the MVC application
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder ConfigureWebApiRouting(this IApplicationBuilder app)
        {
            app.UseStaticFiles();

            //Uncomment this line of code if you wish to use the MVC with the default routing
            app.UseMvc();                

            return app;
        }
    }
}
