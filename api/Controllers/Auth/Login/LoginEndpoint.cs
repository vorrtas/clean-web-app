using api.DataAcess;

namespace api.Controllers.Auth;

public class LoginEndpoint : Endpoint<LoginRequest, LoginResponse>
{
    private readonly IConfiguration config;
    private readonly ILogger<LoginEndpoint> logger;
    private readonly Context context;

    public LoginEndpoint(IConfiguration config, ILogger<LoginEndpoint> logger, Context context)
    {
        this.logger = logger;
        this.config = config;
        this.context = context;
    }

    public override void Configure()
    {
        Post("auth/login");
        AllowAnonymous();
        Summary(s =>
        {
            Summary(s =>
            {
                s.Summary = "short summary goes here";
                s.Description = "long description goes here";
                s.ExampleRequest = new LoginRequest
                {
                    username = "admin",
                    password = "admin"
                };
                s.Response<LoginResponse>(200, "When valid login request is made");
                s.Response(400, "When invalid login request is made");

            });
        });
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        await context.Users.AddAsync(new User() { Username = "Łukasz", Login = "xd", PasswordHash = "xd" });
        await context.SaveChangesAsync();
        User? usr = await context.Users.FindAsync(1);
        logger.LogCritical(usr?.Login);


        var permissions = new[] { "ManageInventory", "ManageUsers" };

        var jwtToken = JWTBearer.CreateToken(
            signingKey: this.config.GetValue<string>("JWT:KEY"),
            issuer: this.config.GetValue<string>("JWT:ISSUER"),
            audience: this.config.GetValue<string>("JWT:AUDIENCE"),
            expireAt: DateTime.UtcNow.AddHours(8),
            claims: new[] { ("UserName", req.username!), ("Id", "1") },
            roles: new[] { "User" },
            permissions: permissions);

        logger.LogInformation("Valid login");

        await SendAsync(new LoginResponse()
        {
            Id = 1,
            UserName = req.username,
            Token = jwtToken,
            Claims = permissions
        });
    }


}
