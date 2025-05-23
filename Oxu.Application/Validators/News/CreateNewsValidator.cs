
using FluentValidation;
using Oxu.Domain.DTOs.News;

namespace Oxu.Application.Validators.News
{
    public class CreateNewsValidator : AbstractValidator<CreateNewsDto>
    {
        public CreateNewsValidator()
        {
            RuleFor(x=>x.Title).NotEmpty().WithMessage("Xəbər üçün başlıq təyin edin");
            RuleFor(x=>x.Content).NotEmpty().WithMessage("Xəbər üçün açıqlama yazın");
        }
    }
}
