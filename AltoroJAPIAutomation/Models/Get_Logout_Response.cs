using System.Text.Json.Serialization;

namespace AltoroJAPIAutomation.Models
{
    public class Get_Logout_Response
    {
        [JsonPropertyName("LoggedOut")]
        public string loggedOut { get; set; }
    }
}
