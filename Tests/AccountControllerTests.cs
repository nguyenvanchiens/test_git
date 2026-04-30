using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.DependencyInjection;
using Models.Account;
using Moq;
using ProjectTestGit.Controllers;
using Service.Service;
using Xunit;

namespace Tests
{
    public class AccountControllerTests
    {
        private readonly Mock<IAuthService> _mockAuthService;
        private readonly AccountController _controller;

        public AccountControllerTests()
        {
            _mockAuthService = new Mock<IAuthService>();
            _controller = new AccountController(_mockAuthService.Object);

            var httpContext = new DefaultHttpContext();
            var authenticationServiceMock = new Mock<IAuthenticationService>();
            authenticationServiceMock
                .Setup(x => x.SignInAsync(It.IsAny<HttpContext>(), It.IsAny<string>(), It.IsAny<ClaimsPrincipal>(), It.IsAny<AuthenticationProperties>()))
                .Returns(Task.CompletedTask);
            authenticationServiceMock
                .Setup(x => x.SignOutAsync(It.IsAny<HttpContext>(), It.IsAny<string>(), It.IsAny<AuthenticationProperties>()))
                .Returns(Task.CompletedTask);
            httpContext.RequestServices = new ServiceCollection()
                .AddSingleton(authenticationServiceMock.Object)
                .AddSingleton<IUrlHelperFactory>(new Mock<IUrlHelperFactory>().Object)
                .AddSingleton<ITempDataDictionaryFactory>(new Mock<ITempDataDictionaryFactory>().Object)
                .BuildServiceProvider();
            _controller.ControllerContext = new ControllerContext { HttpContext = httpContext };
            _controller.TempData = new Mock<ITempDataDictionary>().Object;
        }

        [Fact]
        public void Login_Get_ReturnsViewResult()
        {
            var result = _controller.Login();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Login_Post_WithInvalidModel_ReturnsViewWithModel()
        {
            var model = new LoginModel { Username = "", Password = "" };
            _controller.ModelState.AddModelError("Username", "Required");

            var result = await _controller.Login(model);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(model, viewResult.Model);
        }

        [Fact]
        public async Task Login_Post_WithValidCredentials_RedirectsToHome()
        {
            var model = new LoginModel { Username = "admin", Password = "admin123" };
            var user = new UserModel { Id = 1, Username = "admin", Password = "admin123", FullName = "Administrator", Role = "Admin" };
            _mockAuthService.Setup(s => s.Authenticate("admin", "admin123")).Returns(user);

            var result = await _controller.Login(model);

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectResult.ActionName);
            Assert.Equal("Home", redirectResult.ControllerName);
        }

        [Fact]
        public async Task Login_Post_WithInvalidCredentials_ReturnsViewWithError()
        {
            var model = new LoginModel { Username = "admin", Password = "wrongpassword" };
            _mockAuthService.Setup(s => s.Authenticate("admin", "wrongpassword")).Returns((UserModel?)null);

            var result = await _controller.Login(model);

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Equal(model, viewResult.Model);
            Assert.True(_controller.ModelState.ErrorCount > 0);
        }

        [Fact]
        public async Task Logout_RedirectsToLogin()
        {
            var result = await _controller.Logout();

            var redirectResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Login", redirectResult.ActionName);
            Assert.Equal("Account", redirectResult.ControllerName);
        }
    }
}
