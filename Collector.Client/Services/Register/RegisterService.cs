using Collector.Client.Dtos.Login;
using Collector.Client.Dtos.Response;
using Collector.Client.Dtos.User;
using Collector.Client.Utilities.Extensions;
using Collector.Client.Utilities.Options;
using Microsoft.Extensions.Options;
using System.Text;
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
             => await _httpExtension.CustomFormDataAsync<ReqUserDto, ReqUserDto>($"{_appOptions.UrlRegisterUserService}/register", request);

        public async Task SendCodeToEmail(UserEmailDto email)
        { 
            _ = await _httpExtension.CustomPostAsync<nuint, UserEmailDto>($"{_appOptions.UrlRegisterUserService}/send-email", email);
        }

        public async Task<(string, bool)> VerifyCode(UserEmailDto verifyCode)
        {
            var result = await _httpExtension.CustomPostAsync<Response<UserEmailDto>, UserEmailDto>($"{_appOptions.UrlRegisterUserService}/verify-code", verifyCode);

            if(result == null)
            {
                return (string.Empty, true);
            }
            return (result.ErrorMessage, result.IsSuccess);
        }
        public async Task ConfirmEmail(UserEmailDto confirmEmail)
        {
            _ = await _httpExtension.CustomPostAsync<nuint, UserEmailDto>($"{_appOptions.UrlRegisterUserService}/confirm-email", confirmEmail);
        }


    }
}