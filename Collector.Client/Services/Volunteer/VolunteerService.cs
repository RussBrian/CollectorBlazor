using Collector.Client.Dtos.Volunteer;
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
    }
}
