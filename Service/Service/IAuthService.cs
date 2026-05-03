using Models.Account;

namespace Service.Service
{
    public interface IAuthService
    {
        UserModel? Authenticate(string username, string password);
        UserModel? GetUserByUsername(string username);
    }
}
