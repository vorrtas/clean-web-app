global using FastEndpoints;
global using FastEndpoints.Security;
global using FastEndpoints.Swagger;
using api.Infrastructure;

var builder = WebApplication.CreateBuilder();

IConfiguration configuration = builder.Configuration;

builder.Logging.ConfigureLogger(configuration);
builder.Services.ConfigureForwarderdHeaders(configuration);
builder.Services.ConfigureCors(configuration);
builder.Services.ConfigureAuth(configuration);
builder.Services.ConfigureDatabase(configuration);
builder.Services.ConfigureEndpoints(configuration);
builder.Services.ConfigureSwagger(configuration);

var app = builder.Build();

app.SetCors(configuration);
app.SetAuth(configuration);
app.SetEndpoints(configuration);
app.SetFrontend(configuration);
app.SetSwagger(configuration);

var ctx = app.Services.GetRequiredService<api.DataAcess.Context>();
await ctx.Database.EnsureCreatedAsync();

app.Run();
