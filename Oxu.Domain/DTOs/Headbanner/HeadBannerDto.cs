
using Oxu.Domain.Abstractions;
using Oxu.Domain.DTOs.HeadbannerTranslation;

namespace Oxu.Domain.DTOs.Headbanner
{
    public record HeadBannerDto:BaseDto
    {
        public string Content { get; set; } = default!;
        public string PrimaryLanguage { get; set; } = default!;
        public ICollection<HeadbannerTranslationDto>? HeadBannerTranslations { get; set; }

    }
}
