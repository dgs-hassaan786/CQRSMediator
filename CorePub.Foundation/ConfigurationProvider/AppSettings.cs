using System;
using System.Collections.Generic;
using System.Text;

namespace CorePub.Foundation.ConfigurationProvider
{
    public class AppSettings
    {
        public ApplicationSettings ApplicationSettings { get; set; }
        public DatabaseSettings DatabaseSettings { get; set; }
    }

    public class ApplicationSettings
    {
        public string BaseUrl { get; set; }
        public string Version { get; set; }
        public string Environment { get; set; }
    }

    public class DatabaseSettings
    {
        public string MongoConnectionString { get; set; }
    }
}
