
using Oxu.Domain.Enums;

namespace Oxu.Domain.DTOs.HeadbannerTranslation
{
    public record CreateHeadbannerTranslationDto(string Content, LanguageTypes LanguageType, Guid HeadBannerId);
}
