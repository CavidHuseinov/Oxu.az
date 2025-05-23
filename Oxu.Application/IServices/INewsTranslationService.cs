
using Oxu.Domain.DTOs.NewsTranslation;

namespace Oxu.Application.IServices
{
    public interface INewsTranslationService
    {
        Task<ICollection<NewsTranslationDto>> GetAllAsync();
        Task<NewsTranslationDto> GetByIdAsync(Guid id);
        Task<NewsTranslationDto> CreateAsync(CreateNewsTranslationDto dto);
        Task DeleteAsync(Guid id);
    }
}
