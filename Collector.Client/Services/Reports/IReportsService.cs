using Collector.Client.Dtos;
using Collector.Client.Dtos.Reports;
using Collector.Client.Dtos.Response;
using Microsoft.AspNetCore.Components.Forms;

namespace Collector.Client.Services.Reports
{
    public interface IReportsService
    {
        Task<Response<List<ResReportsGetById>>> GetByIdReports(int Id);
        Task<Response<ReqReportDto>> CreateReport(ReqReportDto request);
        Task<List<ResReportsDto>> GetAllReportsByUserId(PaginationDto pagination);
    }
}
