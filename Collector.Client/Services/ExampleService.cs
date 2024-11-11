using Collector.Client.Utilities.Extensions;
using Collector.Client.Utilities.Options;
using Microsoft.Extensions.Options;

namespace Collector.Client.Services
{
    public class ExampleService
    {
        private readonly HttpClientServiceExtensions _httpClientService;
        private readonly AppOptions _appOptions;

        public ExampleService(HttpClientServiceExtensions httpClientService, IOptions<AppOptions> options)
        {
            _httpClientService = httpClientService;
            _appOptions = options.Value;
        }

        public async Task<object?> GetUser() => await _httpClientService.CustomGetAsync<User>(_appOptions.UrlExampleService);
        public async Task<object?> GetUserById(int id) => await _httpClientService.CustomGetAsync<User>(_appOptions.UrlExampleService, id);

        public async Task<ResponseUser?> PostUser(User user)
            => await _httpClientService.CustomPostAsync<ResponseUser, User>(_appOptions.UrlExampleService, user);
    }

    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    public class ResponseUser
    {
        public string Message { get; set; } = string.Empty;
    }
}
