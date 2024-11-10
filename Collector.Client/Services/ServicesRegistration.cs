using Collector.Client.Services.Register;

namespace Collector.Client.Services;

public static class ServicesRegistration
{
    public static void AddServicesRegistration(this IServiceCollection services)
    {
        services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5004") });
        services.AddScoped<IRegisterService,RegisterService>();
    }
}