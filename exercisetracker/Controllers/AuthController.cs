using System.Security.Claims;
using exercisetracker.Services.AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace exercisetracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<ServiceResponse<Guid>>> Register(UserRegister request)
    {
        var response = await _authService.Register(new User { Username = request.Username}, request.Password);

        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] UserLogin userLogin)
    {
        var response = await _authService.Login(userLogin);

        if (!response.Success)
        {
            return BadRequest();
        }
        
        Response.Cookies.Append(key: "jwt", value: response.Data, new CookieOptions
        {
            HttpOnly=false,
            SameSite=SameSiteMode.Strict
        });

        return Ok();
    }
    
    [HttpPost("change-password"), Authorize]
    public async Task<ActionResult<ServiceResponse<bool>>> ChangePassword([FromBody] string newPassword)
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var response = await _authService.ChangePassword(Guid.Parse(userId!), newPassword);

        if (!response.Success)
            return BadRequest(response);

        return Ok(response);
    }
}