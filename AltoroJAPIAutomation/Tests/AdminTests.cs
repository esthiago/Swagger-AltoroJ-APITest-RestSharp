using AltoroJAPIAutomation.Services;
using Xunit;
using Xunit.Abstractions;

namespace AltoroJAPIAutomation.Tests
{
    public class AdminTests
    {
        private readonly ITestOutputHelper output;

        public AdminTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(DisplayName = "Post new user")]
        [Trait("category", "admin")]
        public void Post_NewUser()
        {
            new AdminServiceWorkFlow(output).Validate_PostNewUser(CustomConfigurationProvider.GetSection("addUserBody"), CustomConfigurationProvider.GetSection("tokken"));
        }

        [Fact(DisplayName = "Post Change Password")]
        [Trait("category", "admin")]
        public void Post_ChangePassword()
        {
            new AdminServiceWorkFlow(output).Validate_PostChangePassword(CustomConfigurationProvider.GetSection("changePasswordBody"), CustomConfigurationProvider.GetSection("tokken"));
        }
    }
}
