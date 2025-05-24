
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.Reactions;
using Oxu.Domain.Entities;
using Oxu.Domain.IRepositories;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Persistance.UnitOfWorks;

namespace Oxu.Infrastructure.Services
{
    public class ReactionService : IReactionService
    {
        private readonly IReactionsRepo _command;
        private readonly IQueryRepository<Reactions> _query;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _save;
        public ReactionService(IReactionsRepo command, IQueryRepository<Reactions> query, IMapper mapper, IUnitOfWork save)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
            _save = save;
        }

        public async Task AddReactionAsync(CreateReactionsDto dto, string ipAddress, string userAgent)
        {
            var exists = await _query.GetAllAsync(x => x.NewsId == dto.NewsId &&
            x.IpAddress == ipAddress && x.UserAgent == userAgent,
            enableTracking: true).FirstOrDefaultAsync();

            if (exists != null)
            {
                if (exists.IsLike == dto.IsLike)
                {
                    await _command.DeleteAsync(exists);
                }
                else
                {
                    exists.IsLike = dto.IsLike;
                }
            }
            else
            {
                var newReaction = _mapper.Map<Reactions>(dto);
                newReaction.IpAddress = ipAddress;
                newReaction.UserAgent = userAgent;
                newReaction.CreatedAt.Date = DateTime.UtcNow;
                await _command.CreateAsync(newReaction);
            }
            await _save.SaveChangesAsync();
        }
        public async Task<ICollection<ReactionsDto>> GetRactionsByNewsAsync(Guid newsId)
        {
            var allReactions = await _query.GetAllAsync(x=>x.NewsId == newsId,
                enableTracking:true).ToListAsync();
            return _mapper.Map<ICollection<ReactionsDto>>(allReactions);
        }
    }
}
