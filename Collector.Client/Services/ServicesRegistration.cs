using Collector.Client.Services.Login;
using Collector.Client.Services.Register;
using Collector.Client.Services.Volunteer;

namespace Collector.Client.Services;

public static class ServicesRegistration
{
    public static void AddServicesRegistration(this IServiceCollection services)
    {
        services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5004") });
        services.AddScoped<ILoginService,LoginService>();

        #region Russ
        services.AddScoped<IVolunteerService, VolunteerService>();
        services.AddScoped<IRegisterService, RegisterService>();
        #endregion
    }
}