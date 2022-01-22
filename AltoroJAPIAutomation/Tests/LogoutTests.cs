using AltoroJAPIAutomation.Services;
using Xunit;
using Xunit.Abstractions;

namespace AltoroJAPIAutomation.Tests
{
    public class LogoutTests
    {
        private readonly ITestOutputHelper output;

        public LogoutTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(DisplayName = "Get Logout")]
        [Trait("category", "logout")]
        public void Get_Logout()
        {
            new LogoutServiceWorkFlow(output).Validate_GetLogout();
        }
    }
}
