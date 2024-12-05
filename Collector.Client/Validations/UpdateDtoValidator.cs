using Collector.Client.Dtos.User;
using FluentValidation;

namespace Collector.Client.Validations
{
    public class UpdateDtoValidator : AbstractValidator<ReqUserUpdateDto>
    {
        public UpdateDtoValidator() 
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("El nombre no pueda estar vacio");
        }
    }
}
