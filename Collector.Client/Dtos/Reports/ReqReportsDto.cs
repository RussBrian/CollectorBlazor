using System.ComponentModel.DataAnnotations;

namespace Collector.Client.Dtos.Reports
{
    public class ReqReportDto
    {
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public string FireBaseCode { get; set; } = string.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public IList<string> Files { get; set; } = [];
    }
}
