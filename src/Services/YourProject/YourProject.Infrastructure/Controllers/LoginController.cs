using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YourProject.Application.Services;

namespace YourProject.Infrastructure.Controllers;

[ApiController]
public class LoginController : ControllerBase
{
    private readonly AuthService _authService;

    public LoginController(AuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login()
    {
        var form = await Request.ReadFormAsync();
        var username = form["username"];
        var password = form["password"];

        var redirectUrl = _authService.Login(username, password);
        return Redirect(redirectUrl);
    }

    [HttpGet("authenticated")]
    public IActionResult Authenticated() =>
        Ok(new { Message = "You are authenticated!" });

    [HttpGet("loginfailed")]
    public IActionResult LoginFailed() =>
        Ok(new { Message = "Invalid credentials. Try again." });
}