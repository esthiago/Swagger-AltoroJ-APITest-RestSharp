using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace AltoroJAPIAutomation.Models
{
    public class Post_TransactionsByDates_Response
    {
        public List<Transactions> transactions { get; set; }
    }

    public class Transactions
    {
        [JsonPropertyName("date")]
        public string date { get; set; }

        [JsonPropertyName("amount")]
        public string amount { get; set; }

        [JsonPropertyName("id")]
        public string id { get; set; }

        [JsonPropertyName("type")]
        public string type { get; set; }

        [JsonPropertyName("account")]
        public string account { get; set; }
    }
}
