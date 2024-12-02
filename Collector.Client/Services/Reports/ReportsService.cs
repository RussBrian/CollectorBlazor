using Collector.Client.Dtos;
using Collector.Client.Dtos.Login;
using Collector.Client.Dtos.Reports;
using Collector.Client.Dtos.Response;
using Collector.Client.Helpers;
using Collector.Client.Utilities.Extensions;
using Collector.Client.Utilities.Options;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Extensions.Options;

namespace Collector.Client.Services.Reports
{
    public class ReportsService : IReportsService
    {
        private readonly HttpClientServiceExtensions _httpServiceExtensions;
        private readonly AppOptions _options;
        private readonly ProtectedSessionStorage _protectedSessionStorage;

        public ReportsService(HttpClientServiceExtensions httpServiceExtensions, ProtectedSessionStorage protectedSessionStorage, IOptions<AppOptions> options)
        {
            _protectedSessionStorage = protectedSessionStorage;
            _options = options.Value;
            _httpServiceExtensions = httpServiceExtensions;
        }
        public async Task<List<ResReportsDto>> GetAllReportsByUserId(string UserId, PaginationDto pagination)
        {
            var reports = await _httpServiceExtensions.CustomGetAsync<Response<List<ResReportsDto>>>
                (_options.UrlReportService, $"?fireBaseCode={UserId}");
            var reportResult = reports as Response<List<ResReportsDto>>;

            if (reportResult != null)
            {
                var queryableList = reportResult.Value.OrderByDescending(x => x.Date).AsQueryable();
                return [.. queryableList.Pagination(pagination)];
            }

            return reportResult?.Value ?? [];
        }

        public async Task<Response<List<ResReportsGetById>>> GetByIdReports(int Id)
        {
            var report = await _httpServiceExtensions.CustomGetAsync<Response<List<ResReportsGetById>>>
            (_options.UrlReportService, $"?Id={Id}");
            var reportResult = report as Response<List<ResReportsGetById>>;
            return reportResult ?? new();
        }

        public async Task<Response<ReqReportDto>> CreateReport(ReqReportDto Report)
        {
            var user = await _protectedSessionStorage.GetAsync<ResLoginDto>("session");
            if (!user.Success)
            {
                Report.FireBaseCode = "9zeirWQJnldZ2qizLbalnxjxpQh2";
            }
            var report = await _httpServiceExtensions.CustomFormDataAsync<Response<ReqReportDto>, ReqReportDto>(_options.UrlReportService, Report);
            return report;
        }
    }
}
