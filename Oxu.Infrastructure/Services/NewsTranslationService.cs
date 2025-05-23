
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.NewsTranslation;
using Oxu.Domain.Entities;
using Oxu.Domain.IRepositories;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Persistance.UnitOfWorks;

namespace Oxu.Infrastructure.Services
{
    public class NewsTranslationService : INewsTranslationService
    {
        private readonly IMapper _mapper;
        private readonly INewsTranslationRepo _command;
        private readonly IQueryRepository<NewsTranslation> _query;
        private readonly IUnitOfWork _save;
        private readonly IMemoryCache _memory;
        private readonly string CacheKey = "NewsAndNewsTranslationCacheKey";

        public NewsTranslationService(IMemoryCache memory, IUnitOfWork save, IQueryRepository<NewsTranslation> query, INewsTranslationRepo command, IMapper mapper)
        {
            _memory = memory;
            _save = save;
            _query = query;
            _command = command;
            _mapper = mapper;
        }

        public async Task<NewsTranslationDto> CreateAsync(CreateNewsTranslationDto dto)
        {
            var data = _mapper.Map<NewsTranslation>(dto);
            var newData = await _command.CreateAsync(data);
            await _save.SaveChangesAsync();
            _memory.Set(CacheKey, newData, TimeSpan.FromMinutes(30));
            return _mapper.Map<NewsTranslationDto>(newData);
        }

        public async Task DeleteAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if (dataId == null)
                throw new ArgumentNullException(nameof(dataId), $"Id Tapilmadi,Id:{id}");
            await _command.DeleteAsync(dataId);
            await _save.SaveChangesAsync();
            _memory.Remove(CacheKey);
        }

        public async Task<ICollection<NewsTranslationDto>> GetAllAsync()
        {
            if(_memory.TryGetValue(CacheKey, out var cachedDict))
            {
                return _mapper.Map<ICollection<NewsTranslationDto>>(cachedDict);
            }
            var allData = await _query.GetAllAsync().ToListAsync();
            _memory.Set(CacheKey, allData, TimeSpan.FromMinutes(30));
            return _mapper.Map<ICollection<NewsTranslationDto>>(allData);
        }

        public async Task<NewsTranslationDto> GetByIdAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if(dataId == null) 
                throw new ArgumentNullException(nameof(dataId),$"Id Tapilmadi,Id:{id}");
            return _mapper.Map<NewsTranslationDto>(dataId);
        }
    }
}
