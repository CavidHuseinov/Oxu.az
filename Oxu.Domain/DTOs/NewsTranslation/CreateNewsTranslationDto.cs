
using Oxu.Domain.Enums;

namespace Oxu.Domain.DTOs.NewsTranslation
{
    public record CreateNewsTranslationDto(string Title,string Content, LanguageTypes LanguageType, Guid NewsId);
}
