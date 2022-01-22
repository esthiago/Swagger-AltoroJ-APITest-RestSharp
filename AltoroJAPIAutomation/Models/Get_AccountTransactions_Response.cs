using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace AltoroJAPIAutomation.Models
{
    public class Get_AccountTransactions_Response
    {
        public List<Last_10_transactions> last_10_transactions { get; set; } 
    }

    public class Last_10_transactions
    {
        [JsonPropertyName("date")]
        public string date { get; set; }

        [JsonPropertyName("transaction_type")]
        public string transactiontype { get; set; }

        [JsonPropertyName("ammount")]
        public string ammount { get; set; }
    }
}
