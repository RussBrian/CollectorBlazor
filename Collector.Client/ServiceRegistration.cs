using Collector.Client.Services.Login;
using Collector.Client.Services.Password;
using Collector.Client.Services.Register;
using Collector.Client.Services.Reports;
using Collector.Client.Services.Volunteer;
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

            services.AddScoped<IVolunteerService, VolunteerService>();
            services.AddScoped<SessionManager>();
            services.AddAuthentication();
            services.AddAuthorization();
            services.AddAuthorizationCore();
            
            services.AddScoped<IPasswordService,PasswordService>();
            services.AddScoped<IRegisterService, RegisterService>();
            services.AddHttpClient();

            services.AddTransient<ReportsService>();
            
            services.AddTransient<ILoginService, LoginService>();

            
            services.AddRazorComponents()
                 .AddInteractiveServerComponents();
            services.AddScoped<SessionManager>();
        }
    }
}
