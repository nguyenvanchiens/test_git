using Models.Account;
using Moq;
using Service.Repo;
using Service.Service;
using Xunit;

namespace Tests
{
    public class AuthServiceTests
    {
        private readonly Mock<IAuthRepository> _mockRepository;
        private readonly AuthService _authService;

        public AuthServiceTests()
        {
            _mockRepository = new Mock<IAuthRepository>();
            _authService = new AuthService(_mockRepository.Object);
        }

        [Fact]
        public void Authenticate_WithValidCredentials_ReturnsUser()
        {
            var user = new UserModel { Id = 1, Username = "admin", Password = "admin123", FullName = "Administrator", Role = "Admin" };
            _mockRepository.Setup(r => r.GetUserByUsername("admin")).Returns(user);

            var result = _authService.Authenticate("admin", "admin123");

            Assert.NotNull(result);
            Assert.Equal("admin", result.Username);
        }

        [Fact]
        public void Authenticate_WithInvalidPassword_ReturnsNull()
        {
            var user = new UserModel { Id = 1, Username = "admin", Password = "admin123", FullName = "Administrator", Role = "Admin" };
            _mockRepository.Setup(r => r.GetUserByUsername("admin")).Returns(user);

            var result = _authService.Authenticate("admin", "wrongpassword");

            Assert.Null(result);
        }

        [Fact]
        public void Authenticate_WithNonExistingUser_ReturnsNull()
        {
            _mockRepository.Setup(r => r.GetUserByUsername("nonexistent")).Returns((UserModel?)null);

            var result = _authService.Authenticate("nonexistent", "password");

            Assert.Null(result);
        }

        [Fact]
        public void Authenticate_WithEmptyUsername_ReturnsNull()
        {
            _mockRepository.Setup(r => r.GetUserByUsername("")).Returns((UserModel?)null);

            var result = _authService.Authenticate("", "password");

            Assert.Null(result);
        }

        [Fact]
        public void Authenticate_WithEmptyPassword_ReturnsNull()
        {
            var user = new UserModel { Id = 1, Username = "admin", Password = "admin123", FullName = "Administrator", Role = "Admin" };
            _mockRepository.Setup(r => r.GetUserByUsername("admin")).Returns(user);

            var result = _authService.Authenticate("admin", "");

            Assert.Null(result);
        }

        [Fact]
        public void GetUserByUsername_WithExistingUser_ReturnsUser()
        {
            var user = new UserModel { Id = 1, Username = "admin", Password = "admin123", FullName = "Administrator", Role = "Admin" };
            _mockRepository.Setup(r => r.GetUserByUsername("admin")).Returns(user);

            var result = _authService.GetUserByUsername("admin");

            Assert.NotNull(result);
            Assert.Equal("admin", result.Username);
        }

        [Fact]
        public void GetUserByUsername_WithNonExistingUser_ReturnsNull()
        {
            _mockRepository.Setup(r => r.GetUserByUsername("nonexistent")).Returns((UserModel?)null);

            var result = _authService.GetUserByUsername("nonexistent");

            Assert.Null(result);
        }

        [Fact]
        public void Authenticate_CallsRepositoryGetUserByUsername()
        {
            _mockRepository.Setup(r => r.GetUserByUsername("admin")).Returns((UserModel?)null);

            _authService.Authenticate("admin", "password");

            _mockRepository.Verify(r => r.GetUserByUsername("admin"), Times.Once);
        }
    }
}
