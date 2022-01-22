using System;
using Xunit.Abstractions;
using RestSharp;
using System.Text.Json;
using AltoroJAPIAutomation.Models;

namespace AltoroJAPIAutomation.Helpers
{
    class FeedbackAPIActions
    {
        private readonly ITestOutputHelper LoggerOutput;

        public FeedbackAPIActions(ITestOutputHelper output)
        {
            this.LoggerOutput = output;
        }

        public bool Post_Feedback(Post_Feedback_Request requestBody)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.Post_Feedback +"/submit");
            restRequest.AddJsonBody(JsonSerializer.Serialize(requestBody));

            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
