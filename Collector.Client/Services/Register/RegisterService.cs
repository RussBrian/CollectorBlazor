using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Collector.Client.Services.Register;

    public class RegisterService : IRegisterService
    {
        private readonly HttpClient _httpClient;

        public RegisterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> RegisterUserAsync(ReqRegistrationDto dto, byte[] file = null)
        {
            try
            {
                using var formData = new MultipartFormDataContent();

                if (!string.IsNullOrEmpty(dto.FristName))
                    formData.Add(new StringContent(dto.FristName), "fristName");

                if (!string.IsNullOrEmpty(dto.LastName))
                    formData.Add(new StringContent(dto.LastName), "lastName");

                if (!string.IsNullOrEmpty(dto.UserName))
                    formData.Add(new StringContent(dto.UserName), "userName");

                if (!string.IsNullOrEmpty(dto.Phone))
                    formData.Add(new StringContent(dto.Phone), "phone");

                if (!string.IsNullOrEmpty(dto.Email))
                    formData.Add(new StringContent(dto.Email), "email");

                if (!string.IsNullOrEmpty(dto.Identification))
                    formData.Add(new StringContent(dto.Identification), "identification");

                if (!string.IsNullOrEmpty(dto.Gender))
                    formData.Add(new StringContent(dto.Gender), "gender");

                if (!string.IsNullOrEmpty(dto.Address))
                    formData.Add(new StringContent(dto.Address), "address");

                if (!string.IsNullOrEmpty(dto.Password))
                    formData.Add(new StringContent(dto.Password), "password");

                if (!string.IsNullOrEmpty(dto.RoleId))
                    formData.Add(new StringContent(dto.RoleId), "roleId");

                if (!string.IsNullOrEmpty(dto.Image))
                    formData.Add(new StringContent(dto.Image), "image");

                if (file != null)
                {
                    var fileContent = new ByteArrayContent(file);
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
                    formData.Add(fileContent, "file", "uploadedImage.jpg");
                }

                var response = await _httpClient.PostAsync("http://localhost:5004/api/Authentication/register", formData);

                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Error en la solicitud HTTP: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error general: {ex.Message}");
                throw;
            }
        }
    }

