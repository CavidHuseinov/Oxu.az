
using Oxu.Domain.Abstractions;
using Oxu.Domain.DTOs.NewsAndTag;

namespace Oxu.Domain.DTOs.Tag
{
    public record TagDto:BaseDto
    {
        public string Name { get; init; } = default!;
        public string PrimaryLanguage { get; init; } = default!;
    }
}
