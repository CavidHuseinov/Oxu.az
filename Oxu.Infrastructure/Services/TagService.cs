
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.Tag;
using Oxu.Domain.Entities;
using Oxu.Domain.IRepositories;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Persistance.UnitOfWorks;

namespace Oxu.Infrastructure.Services
{
    public class TagService : ITagService
    {
        private readonly IMapper _mapper;
        private readonly ITagRepo _command;
        private readonly IUnitOfWork _save;
        private readonly IQueryRepository<Tag> _query;
        private readonly IMemoryCache _memory;
        private readonly string CacheKey = "AndCacheKey";
        public TagService(IQueryRepository<Tag> query, IUnitOfWork save, ITagRepo command, IMapper mapper, IMemoryCache memory)
        {
            _query = query;
            _save = save;
            _command = command;
            _mapper = mapper;
            _memory = memory;
        }

        public async Task<TagDto> CreateAsync(CreateTagDto dto)
        {
            var data = _mapper.Map<Tag>(dto);
            var newData = await _command.CreateAsync(data);
            await _save.SaveChangesAsync();
            _memory.Set(CacheKey,newData,TimeSpan.FromMinutes(30));
            return _mapper.Map<TagDto>(newData);
        }

        public async Task DeleteAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if (dataId == null)
                throw new ArgumentNullException(nameof(dataId), $"Id tapilmadi. Id:{id}");
            await _command.DeleteAsync(dataId);
            await _save.SaveChangesAsync();
            _memory.Remove(CacheKey);
        }

        public async Task<ICollection<TagDto>> GetAllAsync()
        {
            if (_memory.TryGetValue(CacheKey, out var result))
                return _mapper.Map<ICollection<TagDto>>(result);
            var allData = await _query.GetAllAsync(include:q=>q.
            Include(x=>x.Tags)).ToListAsync();
            _memory.Set(CacheKey, allData, TimeSpan.FromMinutes(30));
            return _mapper.Map<ICollection<TagDto>>(allData);
        }

        public async Task<TagDto> GetByIdAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if (dataId == null)
                throw new ArgumentNullException(nameof(dataId), $"Id tapilmadi. Id:{id}");
            return _mapper.Map<TagDto>(dataId);
        }
    }
}
