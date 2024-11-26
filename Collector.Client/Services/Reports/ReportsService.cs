using Collector.Client.Dtos;
using Collector.Client.Dtos.Reports;
using Collector.Client.Dtos.Response;
using Collector.Client.Helpers;
using Collector.Client.Utilities.Extensions;
using Collector.Client.Utilities.Options;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Options;

namespace Collector.Client.Services.Reports
{
    public class ReportsService
    {
        private readonly HttpClientServiceExtensions _httpServiceExtensions;
        private readonly AppOptions _options;

        public ReportsService(HttpClientServiceExtensions httpServiceExtensions, IOptions<AppOptions> options)
        {
            _options = options.Value;
            _httpServiceExtensions = httpServiceExtensions;
        }
        public async Task<List<ReportDto>> GetAllReportsByUserId(string UserId, PaginationDto pagination)
        {
            var reports = await _httpServiceExtensions.CustomGetAsync<Response<List<ReportDto>>>
                (_options.UrlReportService, $"?fireBaseCode={UserId}");
            var reportResult = reports as Response<List<ReportDto>>;

            if (reportResult != null)
            {
                var queryableList = reportResult.Value.AsQueryable();
                return [.. queryableList.Pagination(pagination)];
            }

            return reportResult?.Value ?? [];
        }


        private IList<string> GetImagePreview(IList<IBrowserFile> files)
        {
            IList<string> images = [];

            foreach (var file in files)
            {
                var buffer = new byte[file.Size];
                file.OpenReadStream().ReadAsync(buffer);
                images.Add($"data:image/jpeg;base64,{Convert.ToBase64String(buffer)}");
            }
            return images;
        }

        public async Task<ReportDto> CreateReport(ReportDto Report, IList<IBrowserFile> files)
        {
            var images = GetImagePreview(files);
            Report.Files = images;
            var report = await _httpServiceExtensions.CustomFormDataAsync<Response<ReportDto>, ReportDto>(_options.UrlReportService, Report);
            return report.Value;
        }
    }
}
