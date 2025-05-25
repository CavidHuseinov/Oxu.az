
using Oxu.Domain.DTOs.TagTranslation;

namespace Oxu.Application.IServices
{
    public interface ITagTranslationService
    {
        Task<ICollection<TagTranslationDto>> GetAllAsync();
        Task<TagTranslationDto> GetByIdAsync (Guid id);
        Task<TagTranslationDto> CreateAsync(CreateTagTranslationDto dto);
        Task DeleteAsync(Guid id);
    }
}
