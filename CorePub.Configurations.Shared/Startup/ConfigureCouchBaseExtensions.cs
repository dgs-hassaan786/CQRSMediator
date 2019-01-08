using CorePub.AbstractionsProvider.CouchBase;
using CorePub.AbstractionsProvider.CouchBase.Commons;
using CorePub.AbstractionsProvider.CouchBase.IProviders;
using CorePub.Foundation.ConfigurationProvider;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace CorePub.Configurations.Shared.Startup
{
    public partial class ConfigurationExtensions
    {
        public static void ConfigureCouchBase(this IServiceCollection services, IConfiguration configuration)
        {
            AppSettings appSettings = configuration.Get<AppSettings>();
            services.AddCouchbase(client =>
            {
                client.Servers = appSettings.DbProviders.CouchBase.Servers.Select(x => new Uri(x)).ToList();
                client.UseSsl = false;
                client.Username = appSettings.DbProviders.CouchBase.Username;
                client.Password = appSettings.DbProviders.CouchBase.Password;
            })
            
            //We have to register all the buckets here
            .AddCouchbaseBucket<IArticlesBucketProvider>(CouchBaseBuckets.Article_Bucket);

            //Adding bucket as a transient
            services.AddTransient<IBucketService, BucketService>();

            //This is the sample code for configuring without dependency injection
            //ClusterHelper.Initialize(new Couchbase.Configuration.Client.ClientConfiguration()
            //{
            //    Servers = appSettings.DbProviders.CouchBase.Servers.Select(x => new Uri(x)).ToList()
            //}, new PasswordAuthenticator(appSettings.DbProviders.CouchBase.Username, appSettings.DbProviders.CouchBase.Password));
        }

        public static void ClearCouchBaseResources(this IApplicationBuilder app, IApplicationLifetime applicationLifetime)
        {
            applicationLifetime.ApplicationStopped.Register(() =>
            {
                app.ApplicationServices.GetRequiredService<ICouchbaseLifetimeService>().Close();
            });
        }
    }
  
}
