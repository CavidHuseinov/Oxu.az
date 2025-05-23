
using Oxu.Domain.Abstractions;
using Oxu.Domain.Enums;

namespace Oxu.Domain.Entities
{
    public class NewsTranslation:BaseEntity
    {
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public Guid NewsId { get; set; }
        public News? News { get; set; }
        public LanguageTypes LanguageType {  get; set; } 
    }
}
