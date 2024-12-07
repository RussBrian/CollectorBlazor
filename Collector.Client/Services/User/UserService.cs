using Collector.Client.Dtos.Login;
using Collector.Client.Dtos.User;
using Collector.Client.Utilities.Extensions;
using Collector.Client.Utilities.Options;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Extensions.Options;

namespace Collector.Client.Services.User
{
    public class UserService(HttpClientServiceExtensions serviceExtension, IOptions<AppOptions> options,
        ProtectedSessionStorage protectedSessionStorage) : IUserService
    {
        private HttpClientServiceExtensions _serviceExtension = serviceExtension;
        private AppOptions _appOptions = options.Value;
        private ProtectedSessionStorage _protectedSessionStorage = protectedSessionStorage;

        public async Task<UserUpdateDto> GetUserInfoById()
        {
            var user = await _protectedSessionStorage.GetAsync<ResLoginDto>("session");
            if(user.Value == null)
            {
                UserUpdateDto userUpdate = new();
                return userUpdate;
            }
            var response = await _serviceExtension.CustomGetAsync<UserUpdateDto>($"{_appOptions.UrlUserService}/id", user.Value.UserId);

            var userResult = response as UserUpdateDto;
            return userResult ?? new();
        }

        public async Task<(string, bool)> UpdateUser(UserUpdateDto userEdit)
        {
            var user = await _protectedSessionStorage.GetAsync<ResLoginDto>("session");

            userEdit.UserId = user.Value?.UserId ?? string.Empty;

            var response = await _serviceExtension.CustomPutFormDataReportAsync<UserUpdateDto, UserUpdateDto>(_appOptions.UrlUserService, userEdit);

            if(response == null)
            {
                return ("El usuario ha sido actulizado", true);
            }
            else
            {
                return ("Hubo un error al actualizar su usuario", false);
            }
        }
    }
}
