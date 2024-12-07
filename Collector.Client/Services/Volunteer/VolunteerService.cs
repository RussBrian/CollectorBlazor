using Collector.Client.Dtos;
using Collector.Client.Dtos.Login;
using Collector.Client.Dtos.Response;
using Collector.Client.Dtos.Volunteer;
using Collector.Client.Helpers;
using Collector.Client.Utilities.Extensions;
using Collector.Client.Utilities.Options;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Extensions.Options;
using System.Data.SqlTypes;

namespace Collector.Client.Services.Volunteer
{
    public class VolunteerService : IVolunteerService
    {
        private readonly AppOptions _appOptions;
        private readonly HttpClientServiceExtensions _httpExtension;
        private readonly ProtectedSessionStorage _sessionStorage;

        public VolunteerService(
            IOptions<AppOptions> options, 
            HttpClientServiceExtensions httpClient,
            ProtectedSessionStorage storage)
        {
            _appOptions = options.Value;
            _httpExtension = httpClient;
            _sessionStorage = storage;
        }


        #region Controlador de Volunteer

        #region Form
        public async Task<(bool, string)> CreateVolunteer(ResVolunteerDto request)
        {
            var userInSession = await _sessionStorage.GetAsync<ResLoginDto>("session");

            request.FireBaseCode = userInSession.Value?.UserId ?? string.Empty;

            var volunteer = await _httpExtension.CustomFormDataAsync<Response<ResVolunteerDto>, ResVolunteerDto>(_appOptions.UrlVolunteerService, request);

            var result = volunteer as Response<ResVolunteerDto>;

            if (result.IsSuccess)
            {
                return (true, string.Empty);
            }

            return (false, result.ErrorMessage);
        }

        public async Task<ResVolunteerDto?> UpdateVolunteer(ResVolunteerDto request)
        {
            var userInSession = await _sessionStorage.GetAsync<ResLoginDto>("session");

            request.FireBaseCode = userInSession.Value?.UserId ?? string.Empty;

            return await _httpExtension.CustomPutFormDataAsync<ResVolunteerDto, ResVolunteerDto>(_appOptions.UrlVolunteerService, request);
        }

        #endregion

        #region Gets
        public async Task<ResVolunteerDto?> GetVolunteerById(int id)
        {
            var volunteer = await _httpExtension.CustomGetAsync<Response<ResVolunteerDto>>(_appOptions.UrlVolunteerService, id);

            var result = volunteer as Response<ResVolunteerDto>;

            if (!string.IsNullOrEmpty(result?.Value?.ToString()))
            {
                return result.Value;
            }

            return null;
        }

     public async Task<List<ResVolunteerDto>> GetAllVolunteers(PaginationDto pagination)
        {
            var volunteers = await _httpExtension.CustomGetAsync<Response<List<ResVolunteerDto>>>(_appOptions.UrlVolunteerService);

            var result = volunteers as Response<List<ResVolunteerDto>>;
            
            if (result?.Value != null && result?.Value?.Count() != 0)
            {
                var queryableList = result?.Value?.AsQueryable();
                return [.. queryableList?.Pagination(pagination)];
            }

            return [];
        }

        public async Task<List<ResVolunteerDto>> GetAllVolunteersByUser(PaginationDto pagination)
        {
            var user = await _sessionStorage.GetAsync<ResLoginDto>("session");

            var volunteers = await _httpExtension.CustomGetAsync<Response<List<ResVolunteerDto>>>($"{_appOptions.UrlVolunteerService}/user/",user.Value.UserId);

            var result = volunteers as Response<List<ResVolunteerDto>>;

            if (result?.Value != null && result?.Value?.Count() != 0)
            {
                var queryableList = result?.Value?.AsQueryable();
                return [.. queryableList?.Pagination(pagination)];
            }

            return [];
        }
        #endregion

        public async Task DeleteVolunteer(int id)
            => await _httpExtension.CustomDeleteAsync(_appOptions.UrlVolunteerService,id);

        #endregion

        #region Controlador de User/Volunteer
        public async Task<(string, bool)> RegisterUserInVolunteer(ReqUserVolunteerDto request)
        {
            var result = await _httpExtension.CustomPostAsync<Response<ReqUserVolunteerDto>, ReqUserVolunteerDto>(_appOptions.UrlUserVolunteerService, request);
          
            if (result == null)
            {
                return (string.Empty, true);
            }
            return (result.ErrorMessage, result.IsSuccess);
        }


        public async Task<List<ResUserVolunteerDto>> GetAllUserInVolunteer(int id)
        {
            var volunteers = await _httpExtension.CustomGetAsync<Response<List<ResUserVolunteerDto>>>(_appOptions.UrlUserVolunteerService, id);
            var result = volunteers as Response<List<ResUserVolunteerDto>>;
            return result.Value ?? [];
        }

        public async Task DeleteUserInVolunteer(int id, string userId) 
            => await _httpExtension.CustomDeleteAsync($"{_appOptions.UrlUserVolunteerService}?volunteerId={id}&fireBaseCode={userId}");

        #endregion
    }
}
