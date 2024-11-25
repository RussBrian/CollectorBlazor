using Collector.Client.Dtos.Login;
using Collector.Client.Utilities.Extensions;
using Collector.Client.Utilities.Options;
using Microsoft.Extensions.Options;



namespace Collector.Client.Services.Register
{
    public class RegisterService : IRegisterService
    {
        private readonly AppOptions _appOptions;
        private readonly HttpClientServiceExtensions _httpExtension;

        public RegisterService(IOptions<AppOptions> options, HttpClientServiceExtensions httpClient)
        {
            _appOptions = options.Value;
            _httpExtension = httpClient;
        }

        public async Task<ReqUserDto?> CreateUserAsync(ReqUserDto request)
             => await _httpExtension.CustomFormDataAsync<ReqUserDto, ReqUserDto>(_appOptions.UrlRegisterUserService, request);

    }
}

