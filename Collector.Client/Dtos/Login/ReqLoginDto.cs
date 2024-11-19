using Collector.Client.Validations;
using System.ComponentModel.DataAnnotations;

namespace Collector.Client.Dtos.Login
{
    public class ReqLoginDto
    {
        public string Email { get; set; } = string.Empty;

        [LoginValidations]
        public string Password { get; set; } = string.Empty;
    }
}
