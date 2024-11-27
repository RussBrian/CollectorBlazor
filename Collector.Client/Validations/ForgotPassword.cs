using Collector.Client.Dtos.ForgotPassword;
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Collector.Client.Validations
{
    public class ForgotPassword : AbstractValidator<ForgotPasswordModel>
    {
        public ForgotPassword()
        {
            RuleFor(e => e.Email)
                .NotEmpty().WithMessage("El correo electrónico no puede estar vacio.")
                .EmailAddress().WithMessage("El correo electrónco debe tener un formato valido.");
            
            RuleFor(p => p.NewPassword)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage("Debe de digitar una contraseña.")
                 .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[@$!%*#?&])[A-Za-z0-9@$!%*#?&]{8,16}$")
                    .WithMessage("La contraseña debe de estar en un formato valido.");

            RuleFor(cp => cp.ConfirmPassword)
                .Matches(cp => cp.NewPassword).WithMessage("Ambas contraseñas deben de conincidir.");
        }
    }
}
