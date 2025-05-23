
using Oxu.Domain.Abstractions;
using Oxu.Domain.DTOs.HeadbannerTranslation;

namespace Oxu.Domain.DTOs.Headbanner
{
    public record HeadBannerDto:BaseDto
    {
        public string Content { get; init; } = default!;
        public string PrimaryLanguage { get; init; } = default!;
        public ICollection<HeadbannerTranslationDto>? HexadBannerTranslations { get; init; }

    }
}
