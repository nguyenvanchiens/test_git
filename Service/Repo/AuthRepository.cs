using Models.Account;

namespace Service.Repo
{
    public class AuthRepository : IAuthRepository
    {
        private readonly List<UserModel> _users = new()
        {
            new UserModel { Id = 1, Username = "admin", Password = "admin123", FullName = "Administrator", Role = "Admin" },
            new UserModel { Id = 2, Username = "user", Password = "user123", FullName = "Regular User", Role = "User" }
        };

        public List<UserModel> GetAllUsers()
        {
            return _users;
        }

        public UserModel? GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }
    }
}
