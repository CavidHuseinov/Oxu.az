
namespace Oxu.Domain.DTOs.News
{
    public record CreateNewsDto
    {
        public string Url { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public bool IsLike { get; set; }
    }
}
