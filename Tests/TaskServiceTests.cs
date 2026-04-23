using Moq;
using Service.Repo;
using Service.Service;
using Xunit;

namespace Tests
{
    public class TaskServiceTests
    {
        private readonly Mock<ITaskRepository> _mockRepository;
        private readonly TaskService _taskService;

        public TaskServiceTests()
        {
            _mockRepository = new Mock<ITaskRepository>();
            _taskService = new TaskService(_mockRepository.Object);
        }

        [Fact]
        public void Hello_ShouldCallRepositoryGetA()
        {
            _mockRepository.Setup(r => r.GetA()).Returns("value from repo");

            var result = _taskService.Hello();

            Assert.Equal("value from repo", result);
            _mockRepository.Verify(r => r.GetA(), Times.Once);
        }

        [Fact]
        public void Hello2_ShouldCallRepositoryGetB()
        {
            _mockRepository.Setup(r => r.GetB()).Returns("123");

            var result = _taskService.Hello2();

            Assert.Equal("123", result);
            _mockRepository.Verify(r => r.GetB(), Times.Once);
        }

        [Fact]
        public void Hello3_ShouldReturnEmptyString()
        {
            var result = _taskService.Hello3();

            Assert.Equal("", result);
        }

        [Fact]
        public void Hello4_ShouldReturnEmptyString()
        {
            var result = _taskService.Hello4();

            Assert.Equal("", result);
        }

        [Fact]
        public void Hello5_ShouldReturnSuaLoi()
        {
            var result = _taskService.Hello5();

            Assert.Equal("sua loi", result);
        }

        [Fact]
        public void Hello_WhenRepositoryReturnsNull_ShouldReturnNull()
        {
            _mockRepository.Setup(r => r.GetA()).Returns((string)null!);

            var result = _taskService.Hello();

            Assert.Null(result);
        }

        [Fact]
        public void Hello2_WhenRepositoryReturnsEmpty_ShouldReturnEmpty()
        {
            _mockRepository.Setup(r => r.GetB()).Returns("");

            var result = _taskService.Hello2();

            Assert.Empty(result);
        }
    }
}
