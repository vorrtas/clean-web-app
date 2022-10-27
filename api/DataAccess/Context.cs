using Microsoft.EntityFrameworkCore;

namespace api.DataAcess;

public class Context : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
    {
        optionsBuilder.UseSqlite("Filename=MyDatabase.db");
    }
}