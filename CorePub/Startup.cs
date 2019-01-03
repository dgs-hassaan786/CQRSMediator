﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorePub.Configurations.Startup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace CorePub
{
    public class Startup
    {
        private Container container = new Container();

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {            
            services.ConfigureMvc();
            services.ConfigureSimpleInjector(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.ConfigureRouting();

            app.InjectSimpleInjectorDependecy(container);
        }
    }
}
