namespace api.Controllers.Auth;
public class LoginEndpoint : Endpoint<LoginRequest, LoginResponse>
{
    public override void Configure()
    {
        Post("auth/login");
        AllowAnonymous();
    }

    private LoginRequest? validlogin { get; set; } = new LoginRequest() { username = "admin", password = "admin" };
    private IConfiguration config;
    public LoginEndpoint(IConfiguration config)
    {
        this.config = config;
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        if (req == this.validlogin)
        {
            var permissions = new[] { "ManageInventory", "ManageUsers" };

            var jwtToken = JWTBearer.CreateToken(
                signingKey: this.config.GetValue<string>("JWT:KEY"),
                issuer: this.config.GetValue<string>("JWT:ISSUER"),
                audience: this.config.GetValue<string>("JWT:AUDIENCE"),
                expireAt: DateTime.UtcNow.AddHours(8),
                claims: new[] { ("UserName", req.username!), ("Id", "1") },
                roles: new[] { "User" },
                permissions: permissions);

            await SendAsync(new LoginResponse()
            {
                Id = 1,
                UserName = req.username,
                Token = jwtToken,
                Claims = permissions
            });
        }
        else
        {
            ThrowError("The supplied credentials are invalid!");
        }
    }
}
