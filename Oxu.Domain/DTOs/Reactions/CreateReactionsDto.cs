
using Oxu.Domain.Abstractions;

namespace Oxu.Domain.DTOs.Reactions
{
    public record CreateReactionsDto(bool IsLike, Guid NewsId);
}
