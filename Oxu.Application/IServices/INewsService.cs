
using Oxu.Domain.DTOs.News;

namespace Oxu.Application.IServices
{
    public interface INewsService
    {
        Task<ICollection<NewsDto>> GetAllAsync();
        Task<NewsDto> GetByIdAsync(Guid id);
        Task<NewsDto> CreateAsync(CreateNewsDto dto);
        Task DeleteAsync(Guid id);
    }
}
