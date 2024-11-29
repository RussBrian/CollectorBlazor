using System.Text.Json.Serialization;

namespace Collector.Client.Dtos.User
{
    public class UserEmailDto
    {
        public string Email { get; set; } = string.Empty;
        public int Code { get; set; }
    }
}
