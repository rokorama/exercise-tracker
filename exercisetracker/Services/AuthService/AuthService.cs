using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using exercisetracker.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace exercisetracker.Services.AuthService;

public class AuthService : IAuthService
{
    private readonly DataContext _context;
    private readonly IHttpContextAccessor _httpAccessor;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthService(DataContext context, IHttpContextAccessor httpAccessor, UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _httpAccessor = httpAccessor;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task<ServiceResponse<AuthInfo>> Login(UserLogin userLogin)
    {
        var response = new ServiceResponse<AuthInfo>();
        var user = await _userManager.FindByNameAsync(userLogin.Username);
        if (user is null)
        {
            response.Success = false;
            response.Message = "User not found";
            return response;
        }
        if (!BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password))
        {
            response.Success = false;
            response.Message = "Incorrect password";
            return response;
        }

        var token = CreateToken(user);
        var refreshToken = GenerateRefreshToken();

        DotNetEnv.Env.Load();
        _ = int.TryParse(Environment.GetEnvironmentVariable("REFRESH_TOKEN_VALIDITY_DAYS"),
            out int refreshTokenValidity);

        user.RefreshToken = refreshToken;
        user.RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidity);

        await _userManager.UpdateAsync(user);

        response.Data = new AuthInfo
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            RefreshToken = refreshToken,
            Expiration = token.ValidTo
        };

        return response;
    }

    public async Task<ServiceResponse<Guid>> Register(UserRegister userRegister)
    {
        if (await UserExists(userRegister.Username))
        {
            return new ServiceResponse<Guid>
            {
                Success = false,
                Message = "User already exists"
            };
        }

        var id = Guid.NewGuid();
        var user = new User
        {
            Name = userRegister.Username,
            UserName = userRegister.Username,
            Id = id,
            SecurityStamp = id.ToString(),
            Password = BCrypt.Net.BCrypt.HashPassword(userRegister.Password)
        };

        await _userManager.CreateAsync(user, user.Password);

        return new ServiceResponse<Guid>
        {
            Data = user.Id,
            Message = "Registration successful"
        };
    }

    public async Task<bool> UserExists(string username)
    {
        return await _userManager.FindByNameAsync(username) != null;
    }

    private JwtSecurityToken CreateToken(User user)
    {
        List<Claim> claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Role, user.Role)
        };

        DotNetEnv.Env.Load();

        var key = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")!));

        _ = int.TryParse(Environment.GetEnvironmentVariable("TOKEN_VALIDITY_MINS"), out int tokenValidityInMinutes);

        var token = new JwtSecurityToken(
            issuer: Environment.GetEnvironmentVariable("JWT_ISSUER"),
            audience: Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
            expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
            claims: claims,
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature)
        );

        return token;
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

    public async Task<ServiceResponse<UserStoreDto>> GetUser()
    {
        var userId = GetUserId();
        var dbEntry = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
        if (dbEntry is null)
        {
            return new ServiceResponse<UserStoreDto>
            {
                Message = "Could not retrieve user.",
                Success = false
            };
        }

        var userDto = new UserStoreDto
        {
            Id = dbEntry.Id,
            Username = dbEntry.Name,
            Role = dbEntry.Role
        };

        return new ServiceResponse<UserStoreDto>
        {
            Data = userDto
        };
    }

    public Guid GetUserId() => Guid.Parse(_httpAccessor.HttpContext!.User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    private static string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        DotNetEnv.Env.Load();
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
            ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET"))),
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateAudience = true,
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken ||
            !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principal;
    }

    public async Task<ServiceResponse<TokenModel>> RefreshToken(TokenModel oldTokenModel)
    {
        var response = new ServiceResponse<TokenModel>();
        if (oldTokenModel is null)
        {
            response.Success = false;
            response.Message = "Invalid request";
            return response;
        }

        var principal = GetPrincipalFromExpiredToken(oldTokenModel.AccessToken);
        if (principal == null)
        {
            response.Success = false;
            response.Message = "Invalid access token or refresh token";
            return response;
        }

        string username = principal.Identity.Name;
        var user = await _userManager.FindByNameAsync(username);
        if (user == null || user.RefreshToken != oldTokenModel.RefreshToken ||
            user.RefreshTokenExpiryTime <= DateTime.Now)
        {
            response.Success = false;
            response.Message = "Invalid access token or refresh token";
        }

        var newAccessToken = CreateToken(user);
        var newRefreshToken = GenerateRefreshToken();

        user.RefreshToken = newRefreshToken;
        await _userManager.UpdateAsync(user);

        response.Data = new TokenModel
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
            RefreshToken = newRefreshToken
        };

        return response;
    }
}


// TODO: login() returns an empty string, AuthInfo might be hot garbage
// TODO: sort out the claims when logging in, it seems they're all null