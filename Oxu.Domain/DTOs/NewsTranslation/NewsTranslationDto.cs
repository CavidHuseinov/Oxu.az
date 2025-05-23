
using Oxu.Domain.Abstractions;
using Oxu.Domain.Enums;

namespace Oxu.Domain.DTOs.NewsTranslation
{
    public record NewsTranslationDto:BaseDto
    {
        public string Content { get; init; } = default!;
        public string Title { get; init; }
        public string LanguageType { get; init; } = default!;
    }
}
    