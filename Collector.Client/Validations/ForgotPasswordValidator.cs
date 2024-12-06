using Collector.Client.Dtos.ForgotPassword;
using FluentValidation;

namespace Collector.Client.Validations
{
    public class ForgotPasswordValidator : AbstractValidator<ForgotPasswordModel>
    {
        public ForgotPasswordValidator()
        {
            RuleSet("Step1", () =>
            {
            RuleFor(e => e.Email)
                            .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El correo electrónico no puede estar vacio.")
                .EmailAddress().WithMessage("El correo electrónco debe tener un formato valido.");
            });

            RuleSet("Step2", () =>
            {
                RuleFor(c => c.Code)
                            .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("El código de verificación no puede estar vacío.")
               .GreaterThan(0).WithMessage("El código de verificación debe ser válido")
               .InclusiveBetween(100000, 999999).WithMessage("El código debe ser exactamente 6 dígitos numéricos.");
            });

            RuleSet("Step3", () =>
            {
                RuleFor(p => p.NewPassword)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Debe de digitar una contraseña.")
                .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[@$!%*#?&])[A-Za-z0-9@$!%*#?&]{8,16}$")
                   .WithMessage("La contraseña debe de estar en un formato valido.");

            RuleFor(cp => cp.ConfirmPassword)
                .Cascade(CascadeMode.Stop)
                .Matches(cp => cp.NewPassword).WithMessage("Ambas contraseñas deben de conincidir.");
            });
        }
    }
}
