namespace api.Infrastructure;

public static class Cors
{
    public static IServiceCollection ConfigureCors(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.WithMethods("GET", "PUT", "POST", "DELETE");
                policy.WithOrigins(configuration.GetValue<string>("HOST:ADDRESS"));
                policy.AllowAnyHeader();
            });
        });

        return services;
    }


    public static IApplicationBuilder SetCors(this IApplicationBuilder builder, IConfiguration configuration)
    {
        builder.UseCors();
        return builder;
    }

}