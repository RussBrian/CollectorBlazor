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
            var response = await _serviceExtension.CustomGetAsync<UserUpdateDto>(_appOptions.URLUserService, $"/id/9zeirWQJnldZ2qizLbalnxjxpQh2");

            var userResult = response as UserUpdateDto;
            return userResult ?? new();
        }

        public async Task<(string, bool)> UpdateUser(UserUpdateDto userUpdateDto)
        {
            var user = await _protectedSessionStorage.GetAsync<ResLoginDto>("session");

            var userUpdate = new ReqUserUpdateDto 
            {
                UserName = userUpdateDto.UserName,
                FirstName = userUpdateDto.FirstName,
                LastName = userUpdateDto.LastName,
                Image =  userUpdateDto.Image,
                FireBaseCode = "69lZV6YaZUdfQDKwXHgm8QuC85U2",
                Phone = userUpdateDto.Phone,
            };

            var response = await _serviceExtension.CustomPutAsync<ReqUserUpdateDto>(_appOptions.URLUserService, userUpdate);

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
