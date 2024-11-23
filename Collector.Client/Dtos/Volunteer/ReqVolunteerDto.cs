using System.Text.Json.Serialization;

namespace Collector.Client.Dtos.Volunteer
{
    public class ReqVolunteerDto
    {        
        public string? fireBaseCode { get; set; }        
        public string? name { get; set; }        
        public int volunteerCode { get; set; }
        public string? details { get; set; }       
        public string? longitude { get; set; }
        public string? latitude { get; set; }
        public string? isPrivate { get; set; }
        public DateTime? volunteerDate { get; set; }
        public string? images { get; set; }
    }
}
