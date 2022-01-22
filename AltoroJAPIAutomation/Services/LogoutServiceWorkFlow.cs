using Xunit;
using Xunit.Abstractions;
using AltoroJAPIAutomation.Helpers;

namespace AltoroJAPIAutomation.Services
{
    class LogoutServiceWorkFlow
    {
        private readonly ITestOutputHelper LoggerOutput;

        public LogoutServiceWorkFlow(ITestOutputHelper LoggerOutput)
        {
            this.LoggerOutput = LoggerOutput;
        }

        public void Validate_GetLogout()
        {
           var response = new LogoutAPIActions(LoggerOutput).Get_Logout();
            Assert.NotNull(response);
            Assert.Contains("True", response.loggedOut);
        }
    }
}
