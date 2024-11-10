using Collector.Client.Dtos.Login;
using System.ComponentModel.DataAnnotations;

namespace Collector.Client.Validations
{
    public class LoginValidations : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var model = (ReqLoginDto)validationContext.ObjectInstance;

            if (model.Password.Length >= 20)
            {
                var errorMessage = "Password too long";
                return new ValidationResult(errorMessage,new string[] {validationContext.MemberName});
            }
            return ValidationResult.Success;
        }
    }
}
