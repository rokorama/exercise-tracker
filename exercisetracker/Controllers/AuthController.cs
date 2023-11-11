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

    [HttpGet("lmao")]
    public async Task<ActionResult<ServiceResponse<string>>> Test()
    {
        var result = new ServiceResponse<string>
        {
            Message = "hello"
        };

        return Ok(result);
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
    public async Task<ActionResult<ServiceResponse<string>>> Login([FromBody] UserLogin userLogin)
    {
        var response = await _authService.Login(userLogin);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
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