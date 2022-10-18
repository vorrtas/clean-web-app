namespace api.Controllers.Auth;

public record LoginRequest
{
    public string? username { get; init; }
    public string? password { get; init; }
}