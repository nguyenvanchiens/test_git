using Service.Repo;
using Xunit;

namespace Tests
{
    public class AuthRepositoryTests
    {
        private readonly AuthRepository _repository;

        public AuthRepositoryTests()
        {
            _repository = new AuthRepository();
        }

        [Fact]
        public void GetAllUsers_ReturnsNonEmptyList()
        {
            var result = _repository.GetAllUsers();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetAllUsers_ContainsAdminUser()
        {
            var result = _repository.GetAllUsers();

            Assert.Contains(result, u => u.Username == "admin");
        }

        [Fact]
        public void GetAllUsers_ContainsRegularUser()
        {
            var result = _repository.GetAllUsers();

            Assert.Contains(result, u => u.Username == "user");
        }

        [Fact]
        public void GetUserByUsername_WithExistingUser_ReturnsUser()
        {
            var result = _repository.GetUserByUsername("admin");

            Assert.NotNull(result);
            Assert.Equal("admin", result.Username);
        }

        [Fact]
        public void GetUserByUsername_WithNonExistingUser_ReturnsNull()
        {
            var result = _repository.GetUserByUsername("nonexistent");

            Assert.Null(result);
        }

        [Fact]
        public void GetUserByUsername_IsCaseInsensitive()
        {
            var result = _repository.GetUserByUsername("Admin");

            Assert.NotNull(result);
            Assert.Equal("admin", result.Username);
        }
    }
}
