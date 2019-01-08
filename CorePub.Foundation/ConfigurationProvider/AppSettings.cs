using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CorePub.Foundation.ConfigurationProvider
{
    public class AppSettings
    {
        public ApplicationSettings ApplicationSettings { get; set; }
        public DbProviders DbProviders { get; set; }
    }

    public class ApplicationSettings
    {
        public string BaseUrl { get; set; }
        public string Version { get; set; }
        public string Environment { get; set; }
        public bool IsMock { get; set; } = true;
        public bool IsCamelCaseFormattingToUse { get; set; } = false;
    }

    public class DbProviders
    {
        public class CouchBaseConfig
        {
            public string[] Servers { get; set; }
            public string Password { get; set; }
            public string Username { get; set; }
            public bool UseSsl { get; set; }            
        }

        public class MongoConfig
        {
            public string ConnectionString { get; set; }            
        }

        public class SQLServerConfig
        {
            public string ConnectionString { get; set; }
        }

        public CouchBaseConfig CouchBase { get; set; }
        public MongoConfig Mongo { get; set; }
        public SQLServerConfig SqlServer { get; set; }

    }
}
