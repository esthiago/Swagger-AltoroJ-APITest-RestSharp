using Xunit;
using Xunit.Abstractions;
using System.Text.Json;
using AltoroJAPIAutomation.Helpers;
using AltoroJAPIAutomation.Models;

namespace AltoroJAPIAutomation.Services
{
    class TransferServiceWorkFlow
    {
        private readonly ITestOutputHelper LoggerOutput;

        public TransferServiceWorkFlow(ITestOutputHelper LoggerOutput)
        {
            this.LoggerOutput = LoggerOutput;
        }

        public void Validate_PostTransfer(object jsonInput, string tokken)
        {
            Post_Transfer_Request requestBody = JsonSerializer.Deserialize<Post_Transfer_Request>(jsonInput.ToString());

            var response = new TransferAPIActions(LoggerOutput).Post_Transfer(requestBody, tokken);
            Assert.NotNull(response);
            Assert.Contains("successfully transferred from Account", response.success);
            Assert.Contains(requestBody.transferAmount, response.success);
        }
    }
}
