using Collector.Client.Dtos.Reports;
using Collector.Client.Dtos.Response;
using Collector.Client.Utilities.Extensions;
using Collector.Client.Utilities.Options;
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
        public async Task<List<ReportDto>> GetAllReportsByUserId(string UserId)
        {
            var reports = await _httpServiceExtensions.CustomGetAsync<Response<List<ReportDto>>>
                (_options.UrlReportService, $"?fireBaseCode={UserId}");
            var reportResult = reports as Response<List<ReportDto>>;
            return reportResult?.Value ?? [];
        }
    }
}
