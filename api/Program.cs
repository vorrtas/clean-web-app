global using FastEndpoints;
global using FastEndpoints.Security;
global using FastEndpoints.Swagger;

using api.Infrastructure;

var builder = WebApplication.CreateBuilder();

IConfiguration configuration = builder.Configuration;

builder.Services.ConfigureCors(configuration);
builder.Services.AddFastEndpoints();

builder.Services.AddAuthenticationJWTBearer(
    builder.Configuration.GetValue<string>("JWT:KEY"),
    builder.Configuration.GetValue<string>("JWT:ISSUER"),
    builder.Configuration.GetValue<string>("JWT:AUDIENCE"));

builder.Services.AddSwaggerDoc(shortSchemaNames: true);

builder.Services.AddCors(o => o.AddDefaultPolicy(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));

var app = builder.Build();

app.SetCors(configuration);
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseFastEndpoints(x => x.Endpoints.RoutePrefix = "api");
app.UseOpenApi();
app.UseSwaggerUi3(s => s.ConfigureDefaults());

app.MapGet("/", async (HttpResponse response) => await response.SendRedirectAsync("/index.html", true));

app.Run();
