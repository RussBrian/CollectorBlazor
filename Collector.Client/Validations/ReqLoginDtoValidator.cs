using Collector.Client.Dtos.Login;
using FluentValidation;

namespace Collector.Client.Validations
{
    public class ReqLoginDtoValidator : AbstractValidator<ReqLoginDto>
    {
        public ReqLoginDtoValidator()
        {
            RuleFor(e => e.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Debe de digitar un email.")
            .EmailAddress().WithMessage("El correo electrónico debe de estar en un fórmato valido.");

            RuleFor(p => p.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Debe de digitar una contraseña.")
            .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[@$!%*#?&])[A-Za-z0-9@$!%*#?&]{8,16}$")
                .WithMessage("La contraseña debe de estar en un formato valido.");

        }
    }
}
