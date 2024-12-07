using System.Text.Json.Serialization;

namespace Collector.Client.Dtos.Volunteer
{
    public class ResVolunteerDto
    {
        [JsonPropertyName("volunteerId")]
        public int VolunteerId { get; set; }

        [JsonPropertyName("fireBaseCode")]
        public string FireBaseCode { get; set; } = string.Empty;

        [JsonPropertyName("userImage")]
        public string? UserImage { get; set; }

        [JsonPropertyName("institutionName")]
        public string? InstitutionName { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("longitude")]
        public float Longitude { get; set; }

        [JsonPropertyName("latitude")]
        public float Latitude { get; set; }

        [JsonPropertyName("volunteerCode")]
        public string VolunteerCode { get; set; } = string.Empty;

        [JsonPropertyName("details")]
        public string Details { get; set; } = string.Empty;

        [JsonPropertyName("isPrivate")]
        public bool IsPrivate { get; set; }

        [JsonPropertyName("isActive")]
        public bool IsActive { get; set; } = true;

        [JsonPropertyName("volunteerDate")]
        public string? VolunteerDate { get; set; } 

        [JsonPropertyName("imageUrls")]
        public List<string> ImageUrls { get; set; } = new List<string>();
        public List<IFormFile>? Images { get; set; } = [];
    }
}