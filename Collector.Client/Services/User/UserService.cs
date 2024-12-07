using Collector.Client.Dtos.Login;
using Collector.Client.Dtos.Response;
using Collector.Client.Dtos.User;
using Collector.Client.Utilities.Extensions;
using Collector.Client.Utilities.Options;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Net.Http.Headers;


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

        public async Task<(string, bool)> UpdateUser(UserUpdateDto request)
        {
            var user = await _protectedSessionStorage.GetAsync<ResLoginDto>("session");
            request.UserId = user.Value?.UserId;

            using var client = new HttpClient();
            var data = new HttpRequestMessage(HttpMethod.Put, $"{_appOptions.UrlUserService}");
            var formDataContent = new MultipartFormDataContent
            {
                { new StringContent(request.FirstName ?? string.Empty), "firstName" },
                { new StringContent(request.LastName ?? string.Empty), "lastName" },
                { new StringContent(request.UserName ?? string.Empty), "username" },
                { new StringContent(request.Phone ?? string.Empty), "phone" },
                { new StringContent(request.UserId ?? string.Empty), "userId" },

            };

            if (request.File != null)
            {
                var fileStream = request.File.OpenReadStream();
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(request.File.ContentType);
                formDataContent.Add(fileContent, "file", request.File.Name);
            }

            formDataContent.Add(new StringContent(request.Image ?? string.Empty), "Image");
            formDataContent.Add(new StringContent(request.Address), "address");
            formDataContent.Add(new StringContent(DateTime.Now.ToString()), "dateModified");
            formDataContent.Add(new StringContent("DEFAULT"), "modifiedBy");

            data.Content = formDataContent;

            var response = await client.SendAsync(data);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {response.StatusCode}, Details: {errorContent}");
                return ("Hubo un error al actualizar su usuario", false);
            }

            var responseData = await response.Content.ReadAsStringAsync();
            return ("El usuario ha sido actulizado", true);

        }
    }
}
