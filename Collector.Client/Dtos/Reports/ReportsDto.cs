namespace Collector.Client.Dtos.Reports
{
    public class ReportDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        // User Info
        public string Name { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string? ProfilePicture { get; set; }
        public string Email { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Status { get; set; } = null!;
        public List<string>? ImageUrls { get; set; }
    }
}
