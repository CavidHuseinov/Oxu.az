
using Oxu.Domain.Abstractions;

namespace Oxu.Domain.DTOs.Tag
{
    public record TagDto:BaseDto
    {
        public string Name { get; init; } = default!;
        public string PrimaryLanguage { get; init; } = default!;
    }
}
