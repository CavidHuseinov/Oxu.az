
using Oxu.Domain.Abstractions;

namespace Oxu.Domain.DTOs.Headbanner
{
    public record HeadBannerDto:BaseDto
    {
        public string Content { get; set; } = default!;
    }
}
