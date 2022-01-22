using System;
using Xunit.Abstractions;
using RestSharp;
using System.Text.Json;
using AltoroJAPIAutomation.Models;

namespace AltoroJAPIAutomation.Helpers
{
    class TransferAPIActions
    {
        private readonly ITestOutputHelper LoggerOutput;

        public TransferAPIActions(ITestOutputHelper output)
        {
            this.LoggerOutput = output;
        }

        public Post_Generic_response Post_Transfer(Post_Transfer_Request requestBody, string tokken)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.Post_Transfer);
            restRequest.AddJsonBody(JsonSerializer.Serialize(requestBody));
            restRequest.AddParameter("Authorization", string.Format("Bearer " + tokken), ParameterType.HttpHeader);

            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Post_Generic_response>(restResponse.Content);
            }
            else
            {
                return null;
            }
        }
    }
}
