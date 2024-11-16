using Collector.Client.Dtos.Login;

namespace Collector.Client.Services.Login
{
    public interface ILoginService
    {
        Task Login(ReqLoginDto loginVm);
        Task Logout(ResLoginDto userVm);
    }
}
