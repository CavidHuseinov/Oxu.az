
using Oxu.Domain.Abstractions;

namespace Oxu.Domain.Entities
{
    public class News : BaseEntity
    {
        public string Url { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public bool IsLike { get; set; }
    }
}
