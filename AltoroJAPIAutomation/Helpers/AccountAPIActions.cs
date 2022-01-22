using System;
using Xunit.Abstractions;
using RestSharp;
using System.Text.Json;
using AltoroJAPIAutomation.Models;

namespace AltoroJAPIAutomation.Helpers
{
    class AccountAPIActions
    {
        private readonly ITestOutputHelper LoggerOutput;

        public AccountAPIActions(ITestOutputHelper output)
        {
            this.LoggerOutput = output;
        }

        public Get_AccountList_Response Get_Account(string tokken)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.Get_Account);

            restRequest.AddParameter("Authorization", string.Format("Bearer " + tokken), ParameterType.HttpHeader);

            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Get_AccountList_Response>(restResponse.Content);
            }
            else
            {
                return null;
            }
        }

        public Get_DetailsAccount_Response Get_AccountById(string accountId, string tokken)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.Get_Account +"/" + accountId);
            restRequest.AddParameter("Authorization", string.Format("Bearer " + tokken), ParameterType.HttpHeader);

            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                LoggerOutput.WriteLine("Operation success!");
                return JsonSerializer.Deserialize<Get_DetailsAccount_Response>(restResponse.Content);
                
            }
            else if(restResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                LoggerOutput.WriteLine("Error: " + System.Net.HttpStatusCode.InternalServerError + " This ID dont exist in this tokken");
                return null; 
            }
            else
            {
                return null;
            }
        }

        public Get_AccountTransactions_Response Get_TransactionsById(string accountId, string tokken)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.GET);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.Get_Account +"/" +accountId +"/transactions");
            restRequest.AddParameter("Authorization", string.Format("Bearer " + tokken), ParameterType.HttpHeader);

            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                LoggerOutput.WriteLine("Operation success!");
                return JsonSerializer.Deserialize<Get_AccountTransactions_Response>(restResponse.Content);
            }
            else if (restResponse.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                LoggerOutput.WriteLine("Error: " + System.Net.HttpStatusCode.InternalServerError + " This ID dont exist in this tokken");
                return null;
            }
            else
            {
                return null;
            }
        }

        public Post_TransactionsByDates_Response Post_AccountTransactionsByDate(Post_TransactionsByDates_Request requestBody, string accountId, string tokken)
        {
            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest(Method.POST);
            IRestResponse restResponse;

            restClient.BaseUrl = new Uri(APIMethods.Get_Account + "/" + accountId + "/transactions");
            restRequest.AddJsonBody(JsonSerializer.Serialize(requestBody));
            restRequest.AddParameter("Authorization", string.Format("Bearer " + tokken), ParameterType.HttpHeader);

            restResponse = restClient.Execute(restRequest);

            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return JsonSerializer.Deserialize<Post_TransactionsByDates_Response>(restResponse.Content);
            }
            else if(restResponse.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                LoggerOutput.WriteLine("Bad request error, verify your inputs");
                return null;
            }
            else if(restResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                LoggerOutput.WriteLine("Unauthenticated error, verify your tokken");
                return null;
            }
            else
            {
                return null;
            }
        }
    }
}
