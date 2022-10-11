namespace api.Controllers;
public class UserLoginEndpoint : Endpoint<LoginRequest>
{
    public override void Configure()
    {
        Post("auth/login");
        AllowAnonymous();
    }

    private LoginRequest? validlogin { get; set; } = new LoginRequest() { username = "admin", password = "admin" };
    private IConfiguration config;
    public UserLoginEndpoint(IConfiguration config)
    {
        this.config = config;
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        if (req == this.validlogin)
        {
            var jwtToken = JWTBearer.CreateToken(
                signingKey: this.config.GetValue<string>("JWT:KEY"),
                expireAt: DateTime.UtcNow.AddHours(8),
                claims: new (string, string)[] { ("Username", req.username ?? ""), ("UserID", "001") },
                roles: new[] { "Admin", "Management" },
                permissions: new[] { "ManageInventory", "ManageUsers" });

            await SendAsync(new
            {
                Username = req.username ?? "",
                Token = jwtToken
            });
        }
        else
        {
            ThrowError("The supplied credentials are invalid!");
        }
    }
}
