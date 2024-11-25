using Microsoft.AspNetCore.Authentication.Cookies;

namespace Collector.Client.Middleware
{
    public static class AuthMiddleware
    {
        public static void AuthMiddlewareRedirection(this IServiceCollection service)
        {
            service.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "auth_token";
                    options.LoginPath = "/";
                    options.LogoutPath = "/";
                    options.AccessDeniedPath = "/Access/Denied";
                });

            service.AddAuthentication();
        }
    }
}
