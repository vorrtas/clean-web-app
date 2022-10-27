namespace api.DataAcess;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Login { get; set; }
    public string? PasswordHash { get; set; }
    public string? PasswordSalt { get; set; }
    public ICollection<Permission>? Permissions { get; set; }
}