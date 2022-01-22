using System.Text.Json.Serialization;

namespace AltoroJAPIAutomation.Models
{
    class Get_Login_Response
    {
        [JsonPropertyName("loggedin")]
        public string loggedin { get; set; }
    }
}
