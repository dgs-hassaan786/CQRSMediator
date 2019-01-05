using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace CorePub.Configurations.Startup
{
    public partial class ConfigurationExtensions
    {
        public static IApplicationBuilder ConfigureEnvironment(this IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            return app;
        }
    }
}
