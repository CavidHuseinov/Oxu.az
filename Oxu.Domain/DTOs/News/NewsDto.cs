
using Oxu.Domain.Abstractions;

namespace Oxu.Domain.DTOs.News
{
    public record NewsDto:BaseDto
    {
        public string Url { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public string IsLike { get; set; } = default!;
    }
}
