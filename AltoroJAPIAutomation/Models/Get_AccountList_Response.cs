using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AltoroJAPIAutomation.Models
{
    public class Get_AccountList_Response
    {
        public List<Accounts> accounts { get; set; }
    }

    public class Accounts
    {
        [JsonPropertyName("Name")]
        public string name { get; set; }

        [JsonPropertyName("id")]
        public string id { get; set; }
    }
}
