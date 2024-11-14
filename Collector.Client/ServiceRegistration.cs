using Blazored.LocalStorage;
using Collector.Client.Services.Login;
using Collector.Client.SessionHelpers;

namespace Collector.Client
{
    public static class ServiceRegistration
    {
        public static void AddWebDependencies(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddBlazoredLocalStorage(config => 
            config.JsonSerializerOptions.WriteIndented = true);
            services.AddTransient<ILoginService, LoginService>();
            services.AddRazorComponents()
                 .AddInteractiveServerComponents();
            services.AddHttpContextAccessor();
            services.AddScoped<SessionManager>();
        }
    }
}
