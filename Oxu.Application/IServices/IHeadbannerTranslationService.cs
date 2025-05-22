
using Oxu.Domain.DTOs.Headbanner;
using Oxu.Domain.DTOs.HeadbannerTranslation;

namespace Oxu.Application.IServices
{
    public interface IHeadbannerTranslationService
    {
        Task<ICollection<HeadbannerTranslationDto>> GetAllAsync();
        Task<HeadbannerTranslationDto> GetByIdAsync(Guid id);
        Task<HeadbannerTranslationDto> CreateAsync(CreateHeadbannerTranslationDto dto);
        Task DeleteAsync(Guid id);
    }
}
