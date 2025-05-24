
using Oxu.Domain.Abstractions;
using Oxu.Domain.DTOs.Category;
using Oxu.Domain.DTOs.NewsAndTag;
using Oxu.Domain.DTOs.NewsTranslation;
using Oxu.Domain.Entities;

namespace Oxu.Domain.DTOs.News
{
    public record NewsDto:BaseDto
    {
        public string Url { get; init; } = default!;
        public string Title { get; init; } = default!;
        public string Content { get; init; } = default!;
        public int LikeCount { get; init; }
        public int DislikeCount { get; init; }  
        public string PrimaryLanguage {  get; init; } = default!;
        public ICollection<NewsTranslationDto>? NewsTranslations {  get; init; }
        public CategoryDto? Category {  get; init; } = default!;
        public ICollection<NewsAndTagDto>? NewsAndTags { get; init; }
    }
}
