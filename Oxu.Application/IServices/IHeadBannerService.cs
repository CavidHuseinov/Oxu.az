
using Oxu.Domain.DTOs.Headbanner;

namespace Oxu.Application.IServices
{
    public interface IHeadBannerService
    {
        Task<ICollection<HeadBannerDto>> GetAllAsync();
        Task<HeadBannerDto> GetByIdAsync(Guid id);
        Task<HeadBannerDto> CreateAsync(CreateHeadBannerDto dto);
        Task DeleteAsync(Guid id);
    }
}
