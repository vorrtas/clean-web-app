namespace api.Controllers.Values;

public record GetValuesResponse
{
    public IEnumerable<int>? Values { get; init; }
}