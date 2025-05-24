
using Oxu.Domain.DTOs.Reactions;

namespace Oxu.Domain.DTOs.News
{
    public record CreateNewsDto(string Url, string Title, string Content, Guid CategoryId,ICollection<Guid> TagIds);
}
