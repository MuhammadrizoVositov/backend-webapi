using Microsoft.AspNetCore.Mvc;
using WebSite.Application.Common.Iterface;
using WebSite.Application.Common.Models;

namespace WebSite.Api.Controllers;
[Route("api/accounts")]
[ApiController]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("login")]
    public async ValueTask<IActionResult> Login([FromBody] LoginDetails loginDetails,CancellationToken cancellationToken)
    {
        var token = await authService.LoginAsync(loginDetails,cancellationToken);

        Response.Cookies.Append("token", token);
        
        return Ok(token);
    }

    [HttpPost("Register")]
    public async ValueTask<IActionResult> Register([FromBody] RegistrationDetails registerDetails, CancellationToken cancellationToken)
    {
        var register = await authService.RegisterAsync(registerDetails, cancellationToken);

        return register ? Ok() : BadRequest();
    }
}
