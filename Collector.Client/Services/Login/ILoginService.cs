using Collector.Client.Dtos.Login;
using Collector.Client.Dtos.Response;

namespace Collector.Client.Services.Login
{
    public interface ILoginService
    {
        Task <Response<ResLoginDto>> Login(ReqLoginDto loginVm);
        Task Logout(ResLoginDto userVm);

    }
}
