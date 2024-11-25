using Collector.Client.Dtos;
using Collector.Client.Dtos.Volunteer;

namespace Collector.Client.Services.Volunteer
{
    public interface IVolunteerService
    {
        #region Voluunteer
        Task<ResVolunteerDto?> CreateVolunteer(ReqVolunteerDto request);
        Task<ResVolunteerDto?> RegisterUserInVolunteer(ReqVolunteerDto request);
        Task<List<ResVolunteerDto>> GetAllVolunteers(PaginationDto pagination);
        #endregion

        #region User/Volunteer

        #endregion
    }
}
