using System.ComponentModel.DataAnnotations;
using Models.Account;
using Xunit;

namespace Tests
{
    public class LoginModelTests
    {
        [Fact]
        public void LoginModel_WithValidData_PassesValidation()
        {
            var model = new LoginModel { Username = "admin", Password = "admin123" };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.True(isValid);
            Assert.Empty(results);
        }

        [Fact]
        public void LoginModel_WithoutUsername_FailsValidation()
        {
            var model = new LoginModel { Password = "admin123" };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.MemberNames.Contains("Username"));
        }

        [Fact]
        public void LoginModel_WithoutPassword_FailsValidation()
        {
            var model = new LoginModel { Username = "admin" };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.False(isValid);
            Assert.Contains(results, r => r.MemberNames.Contains("Password"));
        }

        [Fact]
        public void LoginModel_WithEmptyStrings_FailsValidation()
        {
            var model = new LoginModel { Username = "", Password = "" };
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            var isValid = Validator.TryValidateObject(model, context, results, true);

            Assert.False(isValid);
            Assert.True(results.Count >= 2);
        }
    }
}
