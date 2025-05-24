
using Oxu.Domain.Abstractions;
using Oxu.Domain.DTOs.News;

namespace Oxu.Domain.DTOs.Category
{
    public record CategoryDto:BaseDto
    {
        public string Name { get; init; } = default!;
        public string PrimaryLanguage { get; init; } = default!;
    }
}
