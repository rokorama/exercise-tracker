namespace exercisetracker.Services.AuthService;

public interface IAuthService
{
    Task<ServiceResponse<Guid>> Register(UserRegister userRegister);
    Task<bool> UserExists(string username);
    Task<ServiceResponse<AuthInfo>> Login(UserLogin userLogin);
    // Task<ServiceResponse<string>> Login(UserLogin userLogin);
    Task<ServiceResponse<bool>> ChangePassword(Guid userId, string newPassword);
    Task<ServiceResponse<UserStoreDto>> GetUser();
    Task<ServiceResponse<TokenModel>> RefreshToken(TokenModel oldTokenModel);
    Guid GetUserId();
}