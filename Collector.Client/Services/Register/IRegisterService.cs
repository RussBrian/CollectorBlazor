using Collector.Client.Dtos.Login;
using Collector.Client.Dtos.User;

namespace Collector.Client.Services.Register;

public interface IRegisterService
{
    Task<ReqUserDto?> CreateUserAsync(ReqUserDto request);
    Task SendCodeToEmail(UserEmailDto email);
    Task<(string, bool)> VerifyCode(UserEmailDto verifyCode);

    Task ConfirmEmail(UserEmailDto confirmEmail);
}