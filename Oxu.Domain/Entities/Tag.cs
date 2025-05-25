
using Oxu.Domain.Abstractions;

namespace Oxu.Domain.Entities
{
    public class Tag:BaseEntity
    {
        public string Name { get; set; } = default!;
        public string PrimaryLanguage { get; set; } = "AZ";
        public ICollection<NewsAndTag>? NewsAndTags { get; set; }
        public ICollection<TagTranslation>? Tags { get; set; }
    }
}
