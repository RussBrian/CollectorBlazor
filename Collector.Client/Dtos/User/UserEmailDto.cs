using System.Text.Json.Serialization;

namespace Collector.Client.Dtos.User
{
    public class UserEmailDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;
    }
}
