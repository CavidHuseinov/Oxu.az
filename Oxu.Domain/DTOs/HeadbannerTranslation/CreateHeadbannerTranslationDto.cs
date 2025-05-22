
using Oxu.Domain.Enums;

namespace Oxu.Domain.DTOs.HeadbannerTranslation
{
    public record CreateHeadbannerTranslationDto
    {
        public string Content { get; set; } = default!;
        public LanguageTypes LanguageType { get; set; }
        public Guid HeadBannerId { get; set; }
    }
}
