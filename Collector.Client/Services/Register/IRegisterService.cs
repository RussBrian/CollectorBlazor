namespace Collector.Client.Services.Register;

public interface IRegisterService
{
    Task<string> RegisterUserAsync(ReqRegistrationDto dto, byte[] imageFile = null);
}