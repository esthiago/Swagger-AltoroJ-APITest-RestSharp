using AltoroJAPIAutomation.Services;
using Xunit;
using Xunit.Abstractions;

namespace AltoroJAPIAutomation.Tests
{
    public class FeedbackTests
    {
        private readonly ITestOutputHelper output;

        public FeedbackTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(DisplayName = "Post Feedback")]
        [Trait("category", "feedback")]
        public void Post_Feedback()
        {
            new FeedbackServiceWorkFlow(output).Validate_PostFeedback(CustomConfigurationProvider.GetSection("feedbackBody"));
        }

        //DEPENDENCE: GET FEEDBACK BY ID DOES NOT HAVE FEEDBACKID FIELD
    }
}
