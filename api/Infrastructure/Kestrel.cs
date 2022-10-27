using Microsoft.AspNetCore.HttpOverrides;

namespace api.Infrastructure;

public static class Kestrel
{
    public static IServiceCollection ConfigureForwarderdHeaders(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<ForwardedHeadersOptions>(options =>
        {
            options.ForwardedHeaders =
                ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
        });

        return services;
    }
}