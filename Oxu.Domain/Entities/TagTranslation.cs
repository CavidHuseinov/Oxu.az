
using Oxu.Domain.Abstractions;
using Oxu.Domain.Enums;

namespace Oxu.Domain.Entities
{
    public class TagTranslation:BaseEntity
    {
        public string Name { get; set; } = default!;
        public LanguageTypes LanguageType { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; } 
    }
}
