
using Oxu.Domain.Abstractions;

namespace Oxu.Domain.Entities
{
    public class News : BaseEntity
    {
        public string Url { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public ICollection<Reactions>? Reactions { get; set; }
        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public string PrimaryLanguage { get; } = "AZ";
        public ICollection<NewsTranslation>? NewsTranslations { get; set; }
        public Category? Category { get; set; }
        public Guid CategoryId { get; set; }
        public ICollection<NewsAndTag>? NewsAndTags { get; set; }
    }
}
