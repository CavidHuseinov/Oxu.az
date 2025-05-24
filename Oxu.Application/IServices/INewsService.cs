
using Oxu.Domain.DTOs.News;
using Oxu.Domain.DTOs.Reactions;

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
