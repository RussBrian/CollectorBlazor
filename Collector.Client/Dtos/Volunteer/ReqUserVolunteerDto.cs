﻿using System.Text.Json.Serialization;

namespace Collector.Client.Dtos.Volunteer
{
    public class ReqUserVolunteerDto
    {
        [JsonPropertyName("volunteerId")]
        public int VolunteerId { get; set; }

        [JsonPropertyName("fireBaseCode")]
        public string? UserId { get; set; }

        [JsonPropertyName("VolunteerCode")]
        public string? VolunteerCode { get; set; }
    }
}