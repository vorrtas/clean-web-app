namespace api.Controllers.Auth;

public record LoginResponse
{
    public int Id { get; init; }
    public string? UserName { get; init; }
    public string? Token { get; init; }
    public IEnumerable<string>? Claims { get; init; }
}