using Collector.Client.Dtos.ForgotPassword;

namespace Collector.Client.Services.Password
{
    public interface IPasswordService
    {
        Task<ForgotPasswordModel> ForgotPasswordAsync(ForgotPasswordModel forgotPassword);
        Task<ForgotPasswordModel> VerifyCodeAsync(ForgotPasswordModel forgotPassword);
        Task<bool> ResetPasswordAsyncS(string email, string password);
    }
}
