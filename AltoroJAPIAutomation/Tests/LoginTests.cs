using AltoroJAPIAutomation.Services;
using Xunit;
using Xunit.Abstractions;

namespace AltoroJAPIAutomation.Tests
{
    public class LoginTests
    {
        private readonly ITestOutputHelper output;

        public LoginTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(DisplayName = "Get User Loggedin")]
        [Trait("category", "login")]
        public void Get_UserLoggedin()
        {
            new LoginServiceWorkFlow(output).Validate_Get_Login(CustomConfigurationProvider.GetSection("tokken"));
        }

        [Fact(DisplayName = "Post User Authorization")]
        [Trait("category", "login")]
        public void Post_UserAuthorization()
        {
            new LoginServiceWorkFlow(output).Validate_Post_Login(CustomConfigurationProvider.GetSection("requestBodyAuthorization"));
        }

    }
}
