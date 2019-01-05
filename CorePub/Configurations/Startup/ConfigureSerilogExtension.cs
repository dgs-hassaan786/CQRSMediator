using Microsoft.Extensions.Logging;

namespace CorePub.Configurations.Startup
{
    public partial class ConfigurationExtensions
    {
        public static ILoggerFactory ConfigureSerilog(this ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile("Logs/Logs-{Date}.txt");
            return loggerFactory;
        }
    }
}
