namespace api.Controllers;

public record LoginRequest
{
    public string? username { get; init; }
    public string? password { get; init; }
}