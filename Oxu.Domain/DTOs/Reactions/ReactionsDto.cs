
using Oxu.Domain.Abstractions;

namespace Oxu.Domain.DTOs.Reactions
{
    public record ReactionsDto:BaseDto
    {
        public Guid NewsId { get; init; }
        public bool IsLike { get; init; }
    }
}
