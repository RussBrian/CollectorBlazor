using Collector.Client.Utilities.Extensions;
using Collector.Client.Utilities.Options;
using Microsoft.Extensions.Options;

namespace Collector.Client.Services
{
    public class ExampleService(HttpClientServiceExtensions httpClientService, IOptions<AppOptions> options)
    {
        private readonly HttpClientServiceExtensions _httpClientService = httpClientService;
        private readonly AppOptions _appOptions = options.Value;

        public async Task<object?> GetUser() => await _httpClientService.CustomGetAsync<ReqExample>(_appOptions.UrlExampleService);
        public async Task<object?> GetUserById(int id) => await _httpClientService.CustomGetAsync<ReqExample>(_appOptions.UrlExampleService, id);

        public async Task<ResponseExample?> PostUser(ReqExample example)
            => await _httpClientService.CustomPostAsync<ResponseExample, ReqExample>(_appOptions.UrlExampleService, example);
    }

    public class ReqExample
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
    }

    public class ResponseExample
    {
        public string Message { get; set; } = string.Empty;
    }
}
