
using Oxu.Domain.Abstractions;
using Oxu.Domain.Enums;

namespace Oxu.Domain.Entities
{
    public class CategoryTranslation:BaseEntity
    {
        public LanguageTypes LanguageType { get; set; }
        public string Name { get; set; } = default!;
        public Category? Category { get; set; }
        public Guid CategoryId { get; set; }
    }
}
