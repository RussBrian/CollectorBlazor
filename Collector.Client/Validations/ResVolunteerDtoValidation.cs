using Collector.Client.Dtos.Volunteer;
using FluentValidation;

namespace Collector.Client.Validations
{

    public class ResVolunteerDtoValidation : AbstractValidator<ResVolunteerDto>
    {
        public ResVolunteerDtoValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Este campo no puede estar vacio.");
            RuleFor(x => x.Details).NotEmpty().WithMessage("Este campo no puede estar vacio.");
            RuleFor(x => x.VolunteerDate).NotEmpty().WithMessage("Este campo no puede estar vacio.");
        }
    }
}
