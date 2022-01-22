using Xunit;
using Xunit.Abstractions;
using System.Text.Json;
using AltoroJAPIAutomation.Helpers;
using AltoroJAPIAutomation.Models;

namespace AltoroJAPIAutomation.Services
{
    class LoginServiceWorkFlow
    {
        private readonly ITestOutputHelper LoggerOutput;

        public LoginServiceWorkFlow(ITestOutputHelper LoggerOutput)
        {
            this.LoggerOutput = LoggerOutput;
        }

        public void Validate_Get_Login(string tokken)
        {
            var response = new LoginAPIActions(LoggerOutput).Get_UserLogin(tokken);
            Assert.NotNull(response);
            Assert.True(response.loggedin == "true");
        }

        public void Validate_Post_Login(object jsonInput)
        {
            Create_Login_Request requestObject = JsonSerializer.Deserialize<Create_Login_Request>(jsonInput.ToString());

            var response = new LoginAPIActions(LoggerOutput).Post_Login(requestObject);

            Assert.NotNull(response);
            Assert.Contains("is now logged in", response.success);
        }
    }
}
