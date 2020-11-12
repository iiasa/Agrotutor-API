using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace IIASA.Lacowiki.API.Core
{
    public static class HostBuilderExtension
    {
        public static IHostBuilder ConfigureSerilogger(this IHostBuilder hostBuilder) =>
            hostBuilder.ConfigureLogging((context, logging) =>
            {
                logging.ClearProviders();

                logging.AddSerilog(new LoggerConfiguration().ReadFrom.Configuration(context.Configuration.GetSection("Logging"))
                    .CreateLogger());
            });
    }
}