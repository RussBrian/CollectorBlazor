namespace Collector.Client.Dtos.Volunteer
{
    public class ReqVolunteerDto
    {
        public string FireBaseCode { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string VolunteerCode { get; set; } = string.Empty;
        public string Details { get; set; } = string.Empty;
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public bool IsPrivate { get; set; }
        public string VolunteerDate { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public List<IFormFile>? Images { get; set; }
    }
}
