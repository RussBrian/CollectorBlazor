using Collector.Client.Dtos.ForgotPassword;
using Collector.Client.Dtos.Response;
using Collector.Client.Utilities.Extensions;
using Collector.Client.Utilities.Options;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace Collector.Client.Services.Password
{
    public class PasswordService : IPasswordService
    {
        private readonly HttpClientServiceExtensions _httpClientFactory;
        private readonly AppOptions appOptions;

        public PasswordService(HttpClientServiceExtensions httpClientFactory,IOptions<AppOptions> options)
        {
            _httpClientFactory = httpClientFactory; 
            appOptions = options.Value;
            
        }
        public async Task<ForgotPasswordModel> ForgotPasswordAsync(ForgotPasswordModel forgotPassword)
        {
            try
            {
                var request = new
                {
                    forgotPassword.Email,
                    forgotPassword.Code,
                };
                string json = JsonConvert.SerializeObject(request);
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                Response<object> response =  await _httpClientFactory.CustomPostAsync<Response<object>,object>(appOptions.UrlForgotPassword, request);
                if (!response.IsSuccess)
                {
                    forgotPassword.IsError = true;
                    forgotPassword.ErrorMessage = response.ErrorMessage;
                    return forgotPassword;
                }
                return forgotPassword;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<bool> ResetPasswordAsyncS(string email, string password)
        {
            try
            {
                string url = @"http://localhost:5004/api/Authentication/reset-password";

                using HttpClient client = new();

                var request = new
                {
                    Email = email,
                    Password = password 
                };
                string json = JsonConvert.SerializeObject(request);
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, httpContent);
                if (!response.IsSuccessStatusCode)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }

        public async Task<ForgotPasswordModel> VerifyCodeAsync(ForgotPasswordModel forgotPassword)
        {
            try
            {
                string url = @"http://localhost:5004/api/Authentication/reset-password";

                using HttpClient client = new();

                var request = new
                {
                    forgotPassword.Email,
                    forgotPassword.Code,
                };
                string json = JsonConvert.SerializeObject(request);
                HttpContent httpContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(url, httpContent);
                if (!response.IsSuccessStatusCode)
                {
                    forgotPassword.IsError = true;
                    forgotPassword.ErrorMessage = await response.Content.ReadAsStringAsync();
                    return forgotPassword;
                }
                return forgotPassword;
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
        }
    }
}
