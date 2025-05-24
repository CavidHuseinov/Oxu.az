
using Oxu.Domain.DTOs.Category;

namespace Oxu.Application.IServices
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(Guid id);
        Task<CategoryDto> CreateAsync(CreateCategoryDto dto);
        Task DeleteAsync(Guid id);
    }
}
