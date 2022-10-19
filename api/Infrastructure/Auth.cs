namespace api.Infrastructure;

public static class Auth
{
    public static IServiceCollection ConfigureAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthenticationJWTBearer(
            configuration.GetValue<string>("JWT:KEY"),
            configuration.GetValue<string>("JWT:ISSUER"),
            configuration.GetValue<string>("JWT:AUDIENCE")
        );

        return services;
    }


    public static IApplicationBuilder SetAuth(this IApplicationBuilder builder, IConfiguration configuration)
    {
        builder.UseAuthentication();
        builder.UseAuthorization();

        return builder;
    }

}