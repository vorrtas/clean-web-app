namespace api.Controllers;

public record GetValuesResponse
{
    public IEnumerable<int>? Values { get; init; }
}