using Collector.Client.Services.Login;
using Collector.Client.Services.Password;
using Collector.Client.Services.Reports;
using Collector.Client.SessionHelpers;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace Collector.Client
{
    public static class ServiceRegistration
    {
        public static void AddWebDependencies(this IServiceCollection services)
        {
            services.AddScoped<ProtectedSessionStorage>();
            services.AddScoped<AuthenticationStateProvider, SessionManager>();
            services.AddScoped<SessionManager>();
            services.AddAuthentication();
            services.AddAuthorizationCore();
            
            services.AddScoped<IPasswordService,PasswordService>();

            services.AddHttpClient();

            services.AddTransient<ReportsService>();
            
            services.AddTransient<ILoginService, LoginService>();
            
            services.AddRazorComponents()
                 .AddInteractiveServerComponents();
            services.AddScoped<SessionManager>();
        }
    }
}
