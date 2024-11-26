using System.Text.Json.Serialization;

namespace Collector.Client.Dtos.User
{
    public class VerifyCodeDto
    {
        [JsonPropertyName("email")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("code")]
        public int Code { get; set; }
    }
}
