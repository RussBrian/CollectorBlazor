using Collector.Client.Dtos;
using Collector.Client.Dtos.Volunteer;

namespace Collector.Client.Services.Volunteer
{
    public interface IVolunteerService
    {
        #region Volunteer
        Task<ResVolunteerDto?> CreateVolunteer(ResVolunteerDto request);
        Task<ResVolunteerDto?> UpdateVolunteer(ResVolunteerDto request); 
        Task<ResVolunteerDto?> GetVolunteerById(int id);
        Task<List<ResVolunteerDto>> GetAllVolunteers(PaginationDto pagination);
        Task<List<ResVolunteerDto>> GetAllVolunteersByUser(PaginationDto pagination);
        Task DeleteVolunteer(int id);
        #endregion

        #region User/Volunteer
        Task<(string, bool)> RegisterUserInVolunteer(ReqUserVolunteerDto request);
        Task<List<ResUserVolunteerDto>> GetAllUserInVolunteer(int id, PaginationDto pagination);
        Task DeleteUserInVolunteer(int id, string userId);
        #endregion
    }
}
