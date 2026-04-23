using ProjectTestGit.Models;
using Xunit;

namespace Tests
{
    public class ErrorViewModelTests
    {
        [Fact]
        public void ShowRequestId_WhenRequestIdIsNull_ShouldReturnFalse()
        {
            var model = new ErrorViewModel { RequestId = null };

            Assert.False(model.ShowRequestId);
        }

        [Fact]
        public void ShowRequestId_WhenRequestIdIsEmpty_ShouldReturnFalse()
        {
            var model = new ErrorViewModel { RequestId = "" };

            Assert.False(model.ShowRequestId);
        }

        [Fact]
        public void ShowRequestId_WhenRequestIdHasValue_ShouldReturnTrue()
        {
            var model = new ErrorViewModel { RequestId = "abc-123" };

            Assert.True(model.ShowRequestId);
        }

        [Fact]
        public void RequestId_ShouldBeSettable()
        {
            var model = new ErrorViewModel();

            model.RequestId = "test-id";

            Assert.Equal("test-id", model.RequestId);
        }

        [Fact]
        public void RequestId_DefaultValue_ShouldBeNull()
        {
            var model = new ErrorViewModel();

            Assert.Null(model.RequestId);
        }
    }
}
