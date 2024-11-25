using System.Text.Json.Serialization;

namespace Collector.Client.Dtos.Volunteer
{
    public class RegisterUserVolunteerDto
    {
        [JsonPropertyName("volunteerId")]
        public int VolunteerId { get; set; }
        
        [JsonPropertyName("fireBaseCode")]
        public string? UserId { get; set; } 
    }
}
