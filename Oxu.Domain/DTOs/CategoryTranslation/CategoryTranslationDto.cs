
namespace Oxu.Domain.DTOs.CategoryTranslation
{
    public record CategoryTranslationDto
    {
        public string Name { get; init; } = default!;
        public string LanguageType { get; init; } = default!;
    }
}
