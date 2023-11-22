using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using exercisetracker.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace exercisetracker.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpAccessor;

    public AuthService(DataContext context, IHttpContextAccessor httpAccessor)
    {
        _context = context;
        _httpAccessor = httpAccessor;
    }

    public async Task<ServiceResponse<string>> Login(UserLogin userLogin)
    {
        var response = new ServiceResponse<string>();
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Username.ToLower().Equals(userLogin.Username.ToLower()));

        if (user is null)
        {
            response.Success = false;
            response.Message = "User not found";
        }
        else if (!BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password))
        {
            response.Success = false;
            response.Message = "Incorrect password";
        }
        else
        {
            response.Data = CreateToken(user);
        }

        return response;
    }

    public async Task<ServiceResponse<Guid>> Register(User user, string password)
    {
        if(await UserExists(user.Username))
        {
            return new ServiceResponse<Guid>
            {
                Success = false,
                Message = "User already exists"
            };
        }
        
        user.Password = BCrypt.Net.BCrypt.HashPassword(password);

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return new ServiceResponse<Guid>
        {
            Data = user.Id,
            Message = "Registration successful"
        };
    }

    public async Task<bool> UserExists(string username)
    {
        return await _context.Users.AnyAsync(user => user.Username.ToLower().Equals(username.ToLower()));
    }

    private string CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new (ClaimTypes.NameIdentifier, user.Id.ToString()),
            new (ClaimTypes.Name, user.Username),
            new (ClaimTypes.Role, user.Role)
        };

        DotNetEnv.Env.Load();
        
        var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(Environment.GetEnvironmentVariable("JWT_TOKEN")));

        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: cred
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);

        return jwt;
    }

    public async Task<ServiceResponse<bool>> ChangePassword(Guid userId, string newPassword)
    {
        var user = await _context.Users.FindAsync(userId);
        if (user is null)
        {
            return new ServiceResponse<bool>
            {
                Success = false,
                Message = "User not found"
            };
        }

        user.Password = BCrypt.Net.BCrypt.HashPassword(newPassword);
        await _context.SaveChangesAsync();

        return new ServiceResponse<bool>
        {
            Data = true,
            Message = "Password has been changed."
        };
    }

    public Guid GetUserId() => Guid.Parse(_httpAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
}