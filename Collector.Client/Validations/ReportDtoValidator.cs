using Collector.Client.Dtos.Reports;
using FluentValidation;

namespace Collector.Client.Validations
{
    public class ReportDtoValidator : AbstractValidator<ReqReportDto>
    {
        public ReportDtoValidator()
        {
            RuleFor(t => t.Title)
                .NotEmpty().WithMessage("El titulo es requerido");
            RuleFor(d => d.Description)
                .NotEmpty().WithMessage("La descripcion es requerida");
        }
    }
}
