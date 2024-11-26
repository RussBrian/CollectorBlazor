using Collector.Client.Dtos.Login;
using Collector.Client.Dtos.User;

namespace Collector.Client.Services.Register;

public interface IRegisterService
{
    Task<ReqUserDto?> CreateUserAsync(ReqUserDto request);
    Task SendCodeToEmail(string email);
    Task<bool> VerifyCode(VerifyCodeDto verifyCode);
}