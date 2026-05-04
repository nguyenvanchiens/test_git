using Models.Account;

namespace Service.Repo
{
    public interface IAuthRepository
    {
        List<UserModel> GetAllUsers();
        UserModel? GetUserByUsername(string username);
    }
}
