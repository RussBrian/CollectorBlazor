using Collector.Client.Dtos.Login;
using FluentValidation;

namespace Collector.Client.Validations
{
    public class ReqLoginDtoValidator : AbstractValidator<ReqLoginDto>
    {
        public ReqLoginDtoValidator() 
        {
            RuleFor(p => p.Email).NotEmpty().WithMessage("Debe de digitar un email");
            RuleFor(p => p.Email).EmailAddress().WithMessage("El email debe de estar en un formato valido");

            RuleFor(p => p.Password).NotEmpty().WithMessage("Debe de digitar una contraseña");
            RuleFor(p => p.Password).Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[@$!%*#?&])[A-Za-z0-9@$!%*#?&]{8,16}$")
                .WithMessage("Las contraseña debe de estar en un formato valido");

        }
    }
}
