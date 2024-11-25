using Collector.Client.Dtos.Login;

namespace Collector.Client.Services.Register;

public interface IRegisterService
{
    Task<ReqUserDto?> CreateUserAsync(ReqUserDto request);
}