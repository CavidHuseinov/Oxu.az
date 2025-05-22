
using Oxu.Domain.Abstractions;

namespace Oxu.Domain.DTOs.HeadbannerTranslation
{
    public record HeadbannerTranslationDto:BaseDto
    {
        public string Content { get; set; } = default!;
        public string LanguageType { get; set; } = default!;
    }
}
