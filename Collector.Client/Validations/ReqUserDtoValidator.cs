using Collector.Client.Dtos.Login;
using FluentValidation;

namespace Collector.Client.Validations
{
    public class ReqUserDtoValidator : AbstractValidator<ReqUserDto>
    {
        public ReqUserDtoValidator()
        {

            RuleSet("Step1", () =>
            {
                RuleFor(p => p.FirstName)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El nombre es requerido.")
                .Matches(@"^[a-zA-Z\s]+$").WithMessage("El nombre no debe contener números ni caracteres especiales ni vocales con tilde.")
                .MaximumLength(50).WithMessage("El nombre no debe exceder 50 caracteres.");

                RuleFor(p => p.UserName)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("El nombre de usuario es requerido.")
                    .Matches(@"^[a-zA-Z][a-zA-Z0-9]*$")
                    .WithMessage("El nombre de usuario debe iniciar con una letra y no contener espacios.");
            });

            RuleSet("Step2", () =>
            {
                RuleFor(p => p.Phone)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El teléfono es requerido.")
                .Matches(@"^[0-9]{10}$")
                .WithMessage("El teléfono debe contener 10 dígitos.");

                RuleFor(p => p.Password)
                    .Cascade(CascadeMode.Stop)
                    .NotEmpty().WithMessage("Debe digitar una contraseña.")
                    .Matches(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[@$!%*#?&])[A-Za-z0-9@$!%*#?&]{8,16}$")
                    .WithMessage("La contraseña debe contener al menos 1 letra mayúscula, 1 minúscula, 1 número y 1 carácter especial, y tener entre 8 y 16 caracteres.");

                RuleFor(p => p.ConfirmPassword)
                    .Cascade(CascadeMode.Stop)
                    .Equal(p => p.Password).WithMessage("Las contraseñas deben coincidir.");
            });
        }
    }
}

