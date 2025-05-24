
using Oxu.Domain.DTOs.CategoryTranslation;

namespace Oxu.Application.IServices
{
    public interface ICategoryTranslationService
    {
        Task<ICollection<CategoryTranslationDto>> GetAllTranslationsAsync();
        Task<CategoryTranslationDto> GetByIdAsync(Guid id);
        Task<CategoryTranslationDto> CreateAsync(CreateCategoryTranslationDto dto);
        Task DeleteAsync(Guid id);
    }
}
