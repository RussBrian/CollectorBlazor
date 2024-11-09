using Collector.Client.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Collector.Client.Validations
{
    public class LoginValidations : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var model = (LoginViewModel)validationContext.ObjectInstance;

            if (model.Password.Length >= 20)
            {
                var errorMessage = "Password too long";
                return new ValidationResult(errorMessage,new string[] {validationContext.MemberName});
            }
            return ValidationResult.Success;
        }
    }
}
