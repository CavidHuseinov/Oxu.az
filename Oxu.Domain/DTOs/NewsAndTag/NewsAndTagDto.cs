
using Oxu.Domain.DTOs.Tag;

namespace Oxu.Domain.DTOs.NewsAndTag
{
    public record NewsAndTagDto
    {
        public TagDto Tag { get; init; } = default!;
    }
}
