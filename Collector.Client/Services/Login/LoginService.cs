using Collector.Client.Dtos.Login;
using Collector.Client.Dtos.Response;
using Collector.Client.SessionHelpers;
using Collector.Client.Utilities.Extensions;
using Collector.Client.Utilities.Options;
using Microsoft.Extensions.Options;

namespace Collector.Client.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly HttpClientServiceExtensions _httpclientService;
        private readonly AppOptions _options;
        private readonly SessionManager _sesionManager;
        public LoginService(HttpClientServiceExtensions httpclienService, IOptions<AppOptions> options,
            SessionManager sessionManager)
        {
            _sesionManager = sessionManager;
            _httpclientService = httpclienService;
            _options = options.Value;
        }

        public async Task<Response<ResLoginDto>> Login(ReqLoginDto loginVm)
        {
           var result = await _httpclientService.CustomPostAsync<Response<ResLoginDto>,
                ReqLoginDto>(_options.UrlLoginService, loginVm);
            if (result.IsSuccess) return result; 
            await _sesionManager.UpdateAuthenticationState(result.Value);
            return result; 
        }

        public async Task Logout(ResLoginDto userVm)
        {
            await _sesionManager.UpdateAuthenticationState(userVm);
        }
    }
}
