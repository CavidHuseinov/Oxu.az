
using Oxu.Domain.Abstractions;
using Oxu.Domain.DTOs.NewsTranslation;

namespace Oxu.Domain.DTOs.News
{
    public record NewsDto:BaseDto
    {
        public string Url { get; init; } = default!;
        public string Title { get; init; } = default!;
        public string Content { get; init; } = default!;
        public string IsLike { get; init; } = default!;
        public string PrimaryLanguage {  get; init; } = default!;
        public ICollection<NewsTranslationDto>? NewsTranslations {  get; init; }
    }
}
