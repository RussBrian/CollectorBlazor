using Collector.Client.Dtos.Volunteer;

namespace Collector.Client.Services.Volunteer
{
    public interface IVolunteerService
    {
        Task<ResVolunteerDto?> CreateVolunteer(ReqVolunteerDto request);
        Task<ResVolunteerDto?> RegisterUserInVolunteer(ReqVolunteerDto request);
    }
}
