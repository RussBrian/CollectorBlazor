using Collector.Client.Dtos.User;

namespace Collector.Client.Services.User
{
    public interface IUserService
    {
        Task<(string, bool)> UpdateUser(UserUpdateDto userUpdateDto);
        Task<UserUpdateDto> GetUserInfoById();
    }
}
