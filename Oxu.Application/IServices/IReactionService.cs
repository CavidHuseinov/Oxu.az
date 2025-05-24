
using Oxu.Domain.DTOs.Reactions;

namespace Oxu.Application.IServices
{
    public interface IReactionService
    {
        Task AddReactionAsync(CreateReactionsDto dto, string ipAddress, string userAgent);
        Task<ICollection<ReactionsDto>> GetRactionsByNewsAsync(Guid newsId);
    }
}
