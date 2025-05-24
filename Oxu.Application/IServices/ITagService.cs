
using Oxu.Domain.DTOs.Tag;

namespace Oxu.Application.IServices
{
    public interface ITagService
    {
        Task<ICollection<TagDto>> GetAllAsync();
        Task<TagDto> GetByIdAsync(Guid id);
        Task<TagDto> CreateAsync(CreateTagDto dto);
        Task DeleteAsync(Guid id);
    }
}
