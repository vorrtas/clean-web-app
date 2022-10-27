using api.DataAcess.Entities;
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


        //.HasData(new User() { Id = 1, Username = "Administrator", Login = "admin", Password = "admin" });

    }

    public DbSet<User> Users { get; set; }
}