
using Oxu.Domain.Abstractions;
using Oxu.Domain.Enums;

namespace Oxu.Domain.Entities
{
    public class HeadBannerTranslation : BaseEntity
    {
        public string Content { get; set; } = default!;
        public LanguageTypes LanguageType { get; set; }
        public Guid HeadBannerId { get; set; }
        public HeadBanner? HeadBanner {  get; set; }
    }
}
