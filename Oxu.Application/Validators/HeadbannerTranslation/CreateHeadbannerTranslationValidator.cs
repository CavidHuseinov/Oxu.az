
using FluentValidation;
using Oxu.Domain.DTOs.HeadbannerTranslation;

namespace Oxu.Application.Validators.HeadbannerTranslation
{
    public class CreateHeadbannerTranslationValidator : AbstractValidator<CreateHeadbannerTranslationDto>
    {
        public CreateHeadbannerTranslationValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Boş hissələri doldurun");
            RuleFor(x => x.LanguageType).NotEmpty().WithMessage("Dil seçin");
        }
    }
}
