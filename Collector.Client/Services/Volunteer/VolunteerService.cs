using Collector.Client.Dtos.Volunteer;
using Collector.Client.Helpers;
using Collector.Client.Utilities.Extensions;
using Collector.Client.Utilities.Options;
using Microsoft.Extensions.Options;

namespace Collector.Client.Services.Volunteer
{
    public class VolunteerService : IVolunteerService
    {
        private readonly AppOptions _appOptions;
        private readonly HttpClientServiceExtensions _httpExtension;

        public VolunteerService(
            IOptions<AppOptions> options, 
            HttpClientServiceExtensions httpClient)
        {
            _appOptions = options.Value;
            _httpExtension = httpClient;
        }

        public async Task<ResVolunteerDto?> CreateVolunteer(ReqVolunteerDto request)
            => await _httpExtension.CustomFormDataAsync<ResVolunteerDto, ReqVolunteerDto>(_appOptions.UrlVolunteerService,request);

        public async Task<ResVolunteerDto?> RegisterUserInVolunteer(ReqVolunteerDto request)
            => await _httpExtension.CustomFormDataAsync<ResVolunteerDto, ReqVolunteerDto>(_appOptions.UrlVolunteerService, request);

        public async Task<List<ResVolunteerDto>> GetAllVolunteers(PaginationDto pagination)
        {
            var volunteers = await _httpExtension.CustomGetAsync<Response<List<ResVolunteerDto>>>(_appOptions.UrlVolunteerService);

            var result = volunteers as Response<List<ResVolunteerDto>>;

            if(result?.Value?.Count != 0)
            {
                var queryableList = result?.Value?.AsQueryable();
                return [.. queryableList?.Pagination(pagination)];
            }

            return [];
        }
    }
}
