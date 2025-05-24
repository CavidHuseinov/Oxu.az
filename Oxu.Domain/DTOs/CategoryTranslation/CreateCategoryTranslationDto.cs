
using Oxu.Domain.Enums;

namespace Oxu.Domain.DTOs.CategoryTranslation
{
    public record CreateCategoryTranslationDto(string Name, LanguageTypes LanguageType,Guid CategoryId);
}
