using System.Text.Json.Serialization;

namespace AltoroJAPIAutomation.Models
{
    public class Post_LoginContent_Response
    {
        [JsonPropertyName("Authorization")]
        public string authorization { get; set; }

        [JsonPropertyName("success")]
        public string success { get; set; }
    }
}
