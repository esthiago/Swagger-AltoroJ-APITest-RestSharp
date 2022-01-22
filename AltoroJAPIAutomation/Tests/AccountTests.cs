using AltoroJAPIAutomation.Services;
using Xunit;
using Xunit.Abstractions;

namespace AltoroJAPIAutomation.Tests
{
    public class AccountTests
    {
        private readonly ITestOutputHelper output;

        public AccountTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact(DisplayName = "Get All Accounts")]
        [Trait("category", "account")]
        public void Get_All_Accounts()
        {
            new AccountServiceWorkFlow(output).Validate_AllAccounts(CustomConfigurationProvider.GetSection("tokken"));
        }

        [Theory(DisplayName = "Get Account details By ID")]
        [InlineData("800002", "YW5OdGFYUm86WkdWdGJ6RXlNelE9Oj8/Bz92P1w=")]
        [InlineData("800003", "YW5OdGFYUm86WkdWdGJ6RXlNelE9Oj8/Bz92P1w=")]
        [InlineData("4539082039396288", "YW5OdGFYUm86WkdWdGJ6RXlNelE9Oj8/Bz92P1w=")]
        public void Get_AccountById(string accountId, string tokken)
        {
            new AccountServiceWorkFlow(output).Validate_AccountById(accountId, tokken);
        }

        [Theory(DisplayName = "Get Account Transactions By ID")]
        [InlineData("800002", "YW5OdGFYUm86WkdWdGJ6RXlNelE9Oj8/Bz92P1w=")]
        [InlineData("800003", "YW5OdGFYUm86WkdWdGJ6RXlNelE9Oj8/Bz92P1w=")]
        [InlineData("4539082039396288", "YW5OdGFYUm86WkdWdGJ6RXlNelE9Oj8/Bz92P1w=")]
        public void Get_AccountTransactionsById(string accountId, string tokken)
        {
            new AccountServiceWorkFlow(output).Validate_AccountTransactions(accountId, tokken);
        }

        [Fact(DisplayName = "Post Account Transactions By Date")]
        [Trait("category", "account")]
        public void Post_AccountTranactionsByDate()
        {
            new AccountServiceWorkFlow(output).Validate_PostAccountTransactionsByDate(CustomConfigurationProvider.GetSection("datesBody"), CustomConfigurationProvider.GetSection("accountId"), CustomConfigurationProvider.GetSection("tokken"));
        }
    }
}
