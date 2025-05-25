
using Oxu.Domain.Abstractions;

namespace Oxu.Domain.DTOs.TagTranslation
{
    public record TagTranslationDto:BaseDto
    {
        public string Name { get; init; } = default!;
        public string LanguageType { get; init; } = default!;
    }
}
