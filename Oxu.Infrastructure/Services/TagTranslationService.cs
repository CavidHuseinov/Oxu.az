
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.TagTranslation;
using Oxu.Domain.Entities;
using Oxu.Domain.IRepositories;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Persistance.UnitOfWorks;

namespace Oxu.Infrastructure.Services
{
    public class TagTranslationService : ITagTranslationService
    {
        private readonly ITagTranslationRepo _command;
        private readonly IQueryRepository<TagTranslation> _query;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _save;
        private readonly IMemoryCache _memory;
        private readonly string CacheKey = "AndCacheKey";
        public TagTranslationService(ITagTranslationRepo command, IQueryRepository<TagTranslation> query, IMapper mapper, IUnitOfWork save, IMemoryCache memory)
        {
            _command = command;
            _query = query;
            _mapper = mapper;
            _save = save;
            _memory = memory;
        }

        public async Task<TagTranslationDto> CreateAsync(CreateTagTranslationDto dto)
        {
            var data = _mapper.Map<TagTranslation>(dto);
            var newData = await _command.CreateAsync(data);
            await _save.SaveChangesAsync();
            _memory.Set(CacheKey, newData, TimeSpan.FromMinutes(30));
            return _mapper.Map<TagTranslationDto>(newData);
        }

        public async Task DeleteAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if (dataId == null)
                throw new ArgumentNullException(nameof(dataId), "Id tapilmadi");
            await _command.DeleteAsync(dataId);
            await _save.SaveChangesAsync();
            _memory.Set(CacheKey, dataId,TimeSpan.FromMinutes(30));
        }

        public async Task<ICollection<TagTranslationDto>> GetAllAsync()
        {
            if(_memory.TryGetValue(CacheKey, out var result))
                return _mapper.Map<ICollection<TagTranslationDto>>(result);
            var allData = await _query.GetAllAsync().ToListAsync();
            _memory.Set(CacheKey, allData,TimeSpan.FromMinutes(30));
            return _mapper.Map<ICollection<TagTranslationDto>>(allData);
        }

        public async Task<TagTranslationDto> GetByIdAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if(dataId == null) 
                throw new ArgumentNullException(nameof(dataId),"Id tapilmadi");
            return _mapper.Map<TagTranslationDto>(dataId);
        }
    }
}
