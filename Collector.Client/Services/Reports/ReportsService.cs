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
        public async Task<List<ResReportsDto>> GetAllReportsByUserId(PaginationDto pagination)
        {
            var user = await _protectedSessionStorage.GetAsync<ResLoginDto>("session");

            var reports = await _httpServiceExtensions.CustomGetAsync<Response<List<ResReportsDto>>>
                (_options.UrlReportService, $"?fireBaseCode={user.Value?.UserId}");
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

        public async Task<Response<ReqReportDto>> CreateReport(ReqReportDto request)
        {
            var user = await _protectedSessionStorage.GetAsync<ResLoginDto>("session");
            request.FireBaseCode = user.Value?.UserId ?? string.Empty;
            var report = await _httpServiceExtensions.CustomFormDataReportAsync<Response<ReqReportDto>, ReqReportDto>(_options.UrlReportService, request);
            return report;
        }
    }
}
