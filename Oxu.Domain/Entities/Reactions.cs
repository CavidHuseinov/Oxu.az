
using Oxu.Domain.Abstractions;

namespace Oxu.Domain.Entities
{
    public class Reactions:BaseEntity
    {
        public Guid NewsId { get; set; }
        public News? News { get; set; }
        public bool IsLike { get; set; }

        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
    }
}
