using Serilog;

namespace api.Infrastructure;

public static class Logger
{
    public static ILoggingBuilder ConfigureLogger(this ILoggingBuilder builder, IConfiguration configuration)
    {
        builder.ClearProviders();

        var logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .WriteTo.File(
                "log.txt",
                rollingInterval: RollingInterval.Day
            )
            .CreateLogger();

        builder.AddSerilog(logger);

        return builder;
    }
}