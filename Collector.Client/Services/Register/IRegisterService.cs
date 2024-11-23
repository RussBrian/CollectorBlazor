using Collector.Client.Dtos.Login;

namespace Collector.Client.Services.Register;

public interface IRegisterService
{
    Task<string> RegisterUserAsync(ReqUserDto dto, byte[] imageFile = null);
}