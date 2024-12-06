using Collector.Client.Dtos.Login;
using Collector.Client.Dtos.Response;
using Collector.Client.Dtos.User;
using Collector.Client.Dtos.Volunteer;
using Collector.Client.Utilities.Extensions;
using Collector.Client.Utilities.Options;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
namespace Collector.Client.Services.Register
{
    public class RegisterService : IRegisterService
    {
        private readonly AppOptions _appOptions;
        private readonly HttpClient _httpClient;
        private readonly HttpClientServiceExtensions _httpExtension;

        public RegisterService(IOptions<AppOptions> options, HttpClientServiceExtensions httpClient, IHttpClientFactory clientFactory)
        {
            _appOptions = options.Value;
            _httpExtension = httpClient;
            _httpClient = clientFactory.CreateClient();
        }

        public async Task<ReqUserDto?> CreateUserAsync(ReqUserDto request)
        {
            using var client = new HttpClient();
            var data = new HttpRequestMessage(HttpMethod.Post, $"{_appOptions.UrlRegisterUserService}/Register");
            var formDataContent = new MultipartFormDataContent
            {
                { new StringContent(request.FirstName ?? string.Empty), "firstName" },
                { new StringContent(request.LastName ?? string.Empty), "lastName" },
                { new StringContent(request.UserName ?? string.Empty), "username" },
                { new StringContent(request.Phone ?? string.Empty), "phone" },
                { new StringContent(request.Email ?? string.Empty), "email" },
                { new StringContent(request.Identification ?? string.Empty), "identification" }
            };

            if (request.File != null)
            {
                var fileStream = request.File.OpenReadStream();
                var fileContent = new StreamContent(fileStream);
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(request.File.ContentType);
                formDataContent.Add(fileContent, "file", request.File.Name);
            }

            formDataContent.Add(new StringContent(request.Image), "Image");
            formDataContent.Add(new StringContent(request.Gender), "gender");
            formDataContent.Add(new StringContent(request.Address), "address");
            formDataContent.Add(new StringContent(request.Password ?? string.Empty), "password");
            formDataContent.Add(new StringContent(request.RolId.ToString()), "roleId");
            formDataContent.Add(new StringContent(request.AddedBy), "addedBy");

            data.Content = formDataContent;

            var response = await client.SendAsync(data);

            if (!response.IsSuccessStatusCode)
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error: {response.StatusCode}, Details: {errorContent}");
                return null;
            }

            var responseData = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<ReqUserDto>(responseData, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task SendCodeToEmail(UserEmailDto email)
        { 
             var response = await _httpExtension.CustomPostAsync<nuint, UserEmailDto>($"{_appOptions.UrlRegisterUserService}/send-email", email);
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

        public async Task<ReqUserDto?> GetUserByEmail(string email)
        {

            var user = await _httpExtension.CustomGetAsync<ReqUserDto>($"{_appOptions.UrlUserService}", email);

            if (user != null)
            {
                return user as ReqUserDto;
            }

            return null;

        }

        public async Task<ReqUserDto?> GetUserByDocumentNumber(string documentNumber)
        {
            var user = await _httpExtension.CustomGetAsync<ReqUserDto>($"{_appOptions.UrlUserService}/documentnumber/", documentNumber);

            if (user != null)
            {
                return user as ReqUserDto;
            }

            return null;
        }
    }
}