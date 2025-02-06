using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YourProject.Application.Services;
using YourProject.Domain.Services;
using YourProject.Infrastructure.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Register services using Dependency Injection
builder.Services.AddScoped<IAuthenticator, Authenticator>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();