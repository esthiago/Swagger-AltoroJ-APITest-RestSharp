using System.Text.Json.Serialization;

namespace AltoroJAPIAutomation.Models
{
    public class Post_Generic_response
    {
        [JsonPropertyName("success")]
        public string success { get; set; }
    }
}
