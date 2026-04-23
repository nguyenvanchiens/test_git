using Models.Account;
using Service.Repo;

namespace Service.Service
{
    public class AuthService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public UserModel? Authenticate(string username, string password)
        {
            var user = _authRepository.GetUserByUsername(username);
            if (user == null)
                return null;

            // TODO: Use password hashing (e.g., BCrypt) instead of plain text comparison
            if (!user.Password.Equals(password))
                return null;

            return user;
        }

        public UserModel? GetUserByUsername(string username)
        {
            return _authRepository.GetUserByUsername(username);
        }
    }
}
