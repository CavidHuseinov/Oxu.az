
using Oxu.Domain.Abstractions;

namespace Oxu.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; } = default!;
        public string PrimaryLanguage { get; set; } = "AZ";
        public ICollection<News>? News { get; set; }
    }
}
