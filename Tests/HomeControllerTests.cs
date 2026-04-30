using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjectTestGit.Controllers;
using Service.Service;
using Xunit;

namespace Tests
{
    public class HomeControllerTests
    {
        private readonly Mock<ITaskService> _mockTaskService;
        private readonly HomeController _controller;

        public HomeControllerTests()
        {
            _mockTaskService = new Mock<ITaskService>();
            _controller = new HomeController(_mockTaskService.Object);
            _controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext()
            };
        }

        [Fact]
        public void Index_ShouldCallTaskServiceHello()
        {
            _mockTaskService.Setup(s => s.Hello()).Returns("hello from service");

            var result = _controller.Index();

            _mockTaskService.Verify(s => s.Hello(), Times.Once);
        }

        [Fact]
        public void Index_ShouldReturnViewResult()
        {
            _mockTaskService.Setup(s => s.Hello()).Returns("test");

            var result = _controller.Index();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_ShouldSetViewBagMessage()
        {
            _mockTaskService.Setup(s => s.Hello()).Returns("hello world");

            _controller.Index();

            Assert.Equal("hello world", _controller.ViewBag.Message);
        }

        [Fact]
        public void Privacy_ShouldReturnViewResult()
        {
            var result = _controller.Privacy();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Error_ShouldReturnViewResultWithErrorViewModel()
        {
            var result = _controller.Error();

            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.IsType<ProjectTestGit.Models.ErrorViewModel>(viewResult.Model);
        }

        [Fact]
        public void Error_ShouldNotCallTaskService()
        {
            _controller.Error();

            _mockTaskService.Verify(s => s.Hello(), Times.Never);
        }
    }
}
