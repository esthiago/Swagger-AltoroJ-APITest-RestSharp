using Xunit;
using Xunit.Abstractions;
using System.Text.Json;
using AltoroJAPIAutomation.Helpers;
using AltoroJAPIAutomation.Models;

namespace AltoroJAPIAutomation.Services
{
    class AccountServiceWorkFlow
    {
        private readonly ITestOutputHelper LoggerOutput;

        public AccountServiceWorkFlow(ITestOutputHelper LoggerOutput)
        {
            this.LoggerOutput = LoggerOutput;
        }

        public void Validate_AllAccounts(string tokken)
        {
            var response = new AccountAPIActions(LoggerOutput).Get_Account(tokken);
            Assert.NotNull(response);
        }

        public void Validate_AccountById(string accountId, string tokken)
        {
            var response = new AccountAPIActions(LoggerOutput).Get_AccountById(accountId, tokken);
            Assert.NotNull(response);
            Assert.True(response.accountId == accountId);
        }

        public void Validate_AccountTransactions(string accountId, string tokken)
        {
            var response = new AccountAPIActions(LoggerOutput).Get_TransactionsById(accountId, tokken);
            Assert.NotNull(response);
        }

        public void Validate_PostAccountTransactionsByDate(object jsonInput, string accountId, string tokken)
        {
            Post_TransactionsByDates_Request requestBody = JsonSerializer.Deserialize<Post_TransactionsByDates_Request>(jsonInput.ToString());

            var response = new AccountAPIActions(LoggerOutput).Post_AccountTransactionsByDate(requestBody, accountId, tokken);
            Assert.NotNull(response);
            Assert.Contains(response.transactions, r => r.account != null); //Verificando o atributo account dos objetos

            /*
            for (int i=0; i<response.transactions.Count; i++)
            {
                Assert.True(response.transactions[i].account != null);
            }
            */
        }
    }
}
