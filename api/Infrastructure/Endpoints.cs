namespace api.Infrastructure;

public static class Endpoint
{
    public static IServiceCollection ConfigureEndpoints(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFastEndpoints();

        return services;
    }


    public static WebApplication SetEndpoints(this WebApplication builder, IConfiguration configuration)
    {
        builder.UseFastEndpoints(x => x.Endpoints.RoutePrefix = "api");

        return builder;
    }

}