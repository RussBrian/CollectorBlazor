namespace Collector.Client.Dtos.Reports
{
    public class ResReportsGetById
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = null!; 
        public string? Description { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Date { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        public string FireBaseCode { get; set; } = String.Empty;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public IList<string> ImageUrls { get; set; } = [];
    }
}
