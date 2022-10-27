using Microsoft.EntityFrameworkCore;

namespace api.DataAcess;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
        if (Users is null) throw new ArgumentNullException(nameof(Users));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<User>().HasIndex(u => u.Login);

        modelBuilder.Entity<Permission>().HasKey(p => p.Id);

        modelBuilder.Entity<User>().HasMany<Permission>(u => u.Permissions).WithMany(p => p.Users);
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Permission> Permissions => Set<Permission>();
}