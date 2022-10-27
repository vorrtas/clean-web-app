using api.DataAcess;
using Microsoft.EntityFrameworkCore;

namespace api.Infrastructure;

public static class Database
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<Context>(options =>
            options.UseSqlite(configuration.GetValue<string>("DB:CN")
        ));
        return services;
    }

}