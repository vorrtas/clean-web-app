namespace api.Infrastructure;

public static class Swagger
{
    public static IServiceCollection ConfigureSwagger(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSwaggerDoc(settings =>
        {
            settings.DocumentName = configuration.GetValue<string>("SWAGGER:DOCUMENT_NAME");
            settings.Title = configuration.GetValue<string>("SWAGGER:TITLE");
            settings.Version = configuration.GetValue<string>("SWAGGER:VERSION");
            settings.Description = configuration.GetValue<string>("SWAGGER:DESCRIPTION");
        }, shortSchemaNames: true);

        return services;
    }

    public static IApplicationBuilder SetSwagger(this IApplicationBuilder builder, IConfiguration configuration)
    {
        builder.UseOpenApi();
        builder.UseSwaggerUi3(s =>
            s.ConfigureDefaults()
        );

        return builder;
    }
}