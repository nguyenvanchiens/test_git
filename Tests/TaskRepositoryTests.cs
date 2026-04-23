using Service.Repo;
using Xunit;

namespace Tests
{
    public class TaskRepositoryTests
    {
        private readonly TaskRepository _repository;

        public TaskRepositoryTests()
        {
            _repository = new TaskRepository();
        }

        [Fact]
        public void GetA_ShouldReturnEmptyString()
        {
            var result = _repository.GetA();

            Assert.Equal("", result);
        }

        [Fact]
        public void GetB_ShouldReturnOne()
        {
            var result = _repository.GetB();

            Assert.Equal("1", result);
        }

        [Fact]
        public void GetA_And_GetB_ShouldReturnDifferentValues()
        {
            var resultA = _repository.GetA();
            var resultB = _repository.GetB();

            Assert.NotEqual(resultA, resultB);
        }

        [Fact]
        public void Constructor_Default_ShouldCreateInstance()
        {
            var repo = new TaskRepository();
            Assert.NotNull(repo);
        }

        [Fact]
        public void Constructor_WithName_ShouldCreateInstance()
        {
            var repo = new TaskRepository("test");
            Assert.NotNull(repo);
        }

        [Fact]
        public void Constructor_WithNameAndDoubles_ShouldCreateInstance()
        {
            var repo = new TaskRepository("test", 1.0, 2.0, 3.0);
            Assert.NotNull(repo);
        }

        [Fact]
        public void Constructor_WithNameDoubleAndString_ShouldCreateInstance()
        {
            var repo = new TaskRepository("test", 1.0, "value");
            Assert.NotNull(repo);
        }
    }
}
