using Collector.Client.Dtos.Reports;
using FluentValidation;

namespace Collector.Client.Validations
{
    public class ReportDtoValidator : AbstractValidator<ReqReportDto>
    {
        public ReportDtoValidator()
        {
            RuleFor(t => t.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("El titulo es requerido.");
            
            RuleFor(d => d.Description)
                .Cascade(CascadeMode.Stop)
                .MaximumLength(600).WithMessage("La descripcion no puede ser mas larga de 600 caracteres.")
                .NotEmpty().WithMessage("La descripcion es requerida.");

        }
    }
}
