using Collector.Client.Validations;
using System.ComponentModel.DataAnnotations;

namespace Collector.Client.Dtos.Login
{
    public class ReqLoginDto
    {
        [Required(ErrorMessage = "Debe de ingresar un correo electrónico")]
        [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$",
            ErrorMessage = "El formato del correo debe de ser válido")]
        public string Email { get; set; } = string.Empty;

        [LoginValidations]
        public string Password { get; set; } = string.Empty;
    }
}
