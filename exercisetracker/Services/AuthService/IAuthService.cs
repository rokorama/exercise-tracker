namespace exercisetracker.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<Guid>> Register(User user, string password);
    Task<bool> UserExists(string username);
    Task<ServiceResponse<string>> Login(UserLogin userLogin);
    Task<ServiceResponse<bool>> ChangePassword(Guid userId, string newPassword);
    Guid GetUserId();
}