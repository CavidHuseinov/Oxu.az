
using FluentValidation;
using Oxu.Domain.DTOs.Headbanner;

namespace Oxu.Application.Validators.Headbanner
{
    public class CreateHeadBannerValidator : AbstractValidator<CreateHeadBannerDto>
    {
        public CreateHeadBannerValidator()
        {
            RuleFor(x => x.Content).NotEmpty().WithMessage("Bos hisseleri doldurun");
        }
    }
}
