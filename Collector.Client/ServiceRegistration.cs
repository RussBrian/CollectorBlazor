using Collector.Client.SessionHelpers;

namespace Collector.Client
{
    public static class ServiceRegistration
    {
        public static void AddWebDependencies(this IServiceCollection services)
        {
            services.AddRazorComponents()
                 .AddInteractiveServerComponents();
            services.AddHttpContextAccessor();
            services.AddScoped<CookieService>();
        }
    }
}
