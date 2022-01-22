using Xunit;
using Xunit.Abstractions;
using System.Text.Json;
using AltoroJAPIAutomation.Models;
using AltoroJAPIAutomation.Helpers;

namespace AltoroJAPIAutomation.Services
{
    class FeedbackServiceWorkFlow
    {
        private readonly ITestOutputHelper LoggerOutput;

        public FeedbackServiceWorkFlow(ITestOutputHelper LoggerOutput)
        {
            this.LoggerOutput = LoggerOutput;
        }

        public void Validate_PostFeedback(object jsonInput)
        {
            Post_Feedback_Request requestBody = JsonSerializer.Deserialize<Post_Feedback_Request>(jsonInput.ToString());

            var response = new FeedbackAPIActions(LoggerOutput).Post_Feedback(requestBody);
            Assert.True(response, "Request error, verify your inputs!");
        }
    }
}
