using System;
using Xunit.Abstractions;
using RestSharp;
using System.Text.Json;
using AltoroJAPIAutomation.Models;

namespace AltoroJAPIAutomation.Helpers
{
    class AdminAPIActions
    {
        private readonly ITestOutputHelper LoggerOutput;

        public AdminAPIActions(ITestOutputHelper LoggerOutput)
        {
            this.LoggerOutput = LoggerOutput;
        }

        public Post_Generic_response Post_NewUser(Post_AddNewUser_Request requestBody, string tokken)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.Post_Admin +"/addUser");
            restRequest.AddJsonBody(JsonSerializer.Serialize(requestBody));
            restRequest.AddParameter("Authorization", string.Format("Bearer " + tokken), ParameterType.HttpHeader);

            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                LoggerOutput.WriteLine("Operation success!");
                return JsonSerializer.Deserialize<Post_Generic_response>(restResponse.Content);
            }
            else if (restResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                LoggerOutput.WriteLine("Error 400, Bad Request. Verify your inputs.");
                return null;
            }
            else if (restResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                LoggerOutput.WriteLine("Error 401, Unauthorized. Verify your tokken.");
                return null;
            }
            else
            {
                LoggerOutput.WriteLine("Error 500, Internal server error.");
                return null;
            }
        }

        public Post_Generic_response Post_ChangePassword(Post_ChangePassword_Request requestBody, string tokken)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.Post_Admin +"/changePassword");
            restRequest.AddJsonBody(JsonSerializer.Serialize(requestBody));
            restRequest.AddParameter("Authorization", string.Format("Bearer " +tokken), ParameterType.HttpHeader);

            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                LoggerOutput.WriteLine("Operation success!");
                return JsonSerializer.Deserialize<Post_Generic_response>(restResponse.Content);
            }
            else if(restResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                LoggerOutput.WriteLine("Error 401, Unauthorized. Verify your tokken.");
                return null;
            }
            else if (restResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                LoggerOutput.WriteLine("Error 400, Bad Request. Verify your inputs.");
                return null;
            }
            else
            {
                LoggerOutput.WriteLine("Error 500, Internal server error.");
                return null;
            }
        }
    }
}
