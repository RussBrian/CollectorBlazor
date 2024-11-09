using Newtonsoft.Json;

namespace Collector.Client.SessionHelpers
{
    public class CookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetCookies(string key,dynamic value)
        {
            var options = new CookieOptions();
            var jsonData = JsonConvert.SerializeObject(value);
            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, jsonData, options);
        }

        public string GetCookie(string key)
        {
            return _httpContextAccessor.HttpContext.Request.Cookies[key];
        }

        public void DeleteCookie(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }
    }
}
