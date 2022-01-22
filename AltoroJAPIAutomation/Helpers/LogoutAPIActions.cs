using System;
using Xunit.Abstractions;
using RestSharp;
using System.Text.Json;
using AltoroJAPIAutomation.Models;

namespace AltoroJAPIAutomation.Helpers
{
    class LogoutAPIActions
    {
        private readonly ITestOutputHelper LoggerOutput;

        public LogoutAPIActions(ITestOutputHelper LoggerOutput)
        {
            this.LoggerOutput = LoggerOutput;
        }

        public Get_Logout_Response Get_Logout()
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.Get_Logout);
            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Get_Logout_Response>(restResponse.Content);
            }
            else
            {
                return null;
            }
        }
    }
}
