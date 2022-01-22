using System;
using Xunit.Abstractions;
using RestSharp;
using System.Text.Json;
using AltoroJAPIAutomation.Models;

namespace AltoroJAPIAutomation.Helpers
{
    class LoginAPIActions
    {
        private readonly ITestOutputHelper LoggerOutput;

        public LoginAPIActions(ITestOutputHelper output)
        {
            this.LoggerOutput = output;
        }

        public Get_Login_Response Get_UserLogin(string tokken)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.Get_Login);

            restRequest.AddParameter("Authorization", string.Format("Bearer " +tokken), ParameterType.HttpHeader);

            restResponse = restClient.Execute(restRequest);

            if(restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Get_Login_Response>(restResponse.Content);
            }
            else
            {
                return null;
            }
        }

        public Post_LoginContent_Response Post_Login(Create_Login_Request requestBody)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.Get_Login);

            restRequest.AddJsonBody(JsonSerializer.Serialize(requestBody));

            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Post_LoginContent_Response>(restResponse.Content);
            }
            else
            {
                return null;
            }
        }
    }
}
