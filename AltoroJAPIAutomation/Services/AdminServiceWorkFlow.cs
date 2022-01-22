using Xunit;
using Xunit.Abstractions;
using System.Text.Json;
using AltoroJAPIAutomation.Models;
using AltoroJAPIAutomation.Helpers;

namespace AltoroJAPIAutomation.Services
{
    class AdminServiceWorkFlow
    {
        private readonly ITestOutputHelper LoggerOutput;

        public AdminServiceWorkFlow(ITestOutputHelper LoggerOutput)
        {
            this.LoggerOutput = LoggerOutput;
        }

        public void Validate_PostNewUser(object jsonInput, string tokken)
        {
            Post_AddNewUser_Request requestBody = JsonSerializer.Deserialize<Post_AddNewUser_Request>(jsonInput.ToString());

            var response = new AdminAPIActions(LoggerOutput).Post_NewUser(requestBody, tokken);
            Assert.NotNull(response);
            Assert.Contains("Requested operation has completed successfully.", response.success);
        }

        public void Validate_PostChangePassword(object jsonInput, string tokken)
        {
            Post_ChangePassword_Request requestBody = JsonSerializer.Deserialize<Post_ChangePassword_Request>(jsonInput.ToString());

            var response = new AdminAPIActions(LoggerOutput).Post_ChangePassword(requestBody, tokken);
            Assert.NotNull(response);
            Assert.Contains("Requested operation has completed successfully.", response.success);
        }
    }
}
