namespace api.Infrastructure;

public static class Frontend
{
    public static WebApplication SetFrontend(this WebApplication builder, IConfiguration configuration)
    {
        builder.UseStaticFiles();

        builder.MapGet("/",
            async (HttpResponse response) =>
            await response.SendRedirectAsync("/index.html", true)
        );

        return builder;
    }

}