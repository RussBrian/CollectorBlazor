namespace Collector.Client.Dtos.Reports
{
    public class ReqReportDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string FireBaseCode { get; set; } = string.Empty;
        public double Latitude { get; set; } = 18.485899;
        public double Longitude { get; set; } = -69.839095;
        public IList<IFormFile> Images { get; set; } = [];
    }
}
