
using Oxu.Domain.Enums;

namespace Oxu.Domain.DTOs.TagTranslation
{
    public record CreateTagTranslationDto(string Name, LanguageTypes LanguageType, Guid TagId);
}
