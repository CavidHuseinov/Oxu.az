
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.CategoryTranslation;
using Oxu.Domain.Entities;
using Oxu.Domain.IRepositories;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Persistance.UnitOfWorks;

namespace Oxu.Infrastructure.Services
{
    public class CategoryTranslationService : ICategoryTranslationService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryTranslationRepo _command;
        private readonly IQueryRepository<CategoryTranslation> _query;
        private readonly IUnitOfWork _save;
        private readonly IMemoryCache _memory;
        private readonly string CacheKey = "AndCacheKey";
        public CategoryTranslationService(IMapper mapper, ICategoryTranslationRepo command, IQueryRepository<CategoryTranslation> query, IUnitOfWork save, IMemoryCache memory)
        {
            _mapper = mapper;
            _command = command;
            _query = query;
            _save = save;
            _memory = memory;
        }

        public async Task<CategoryTranslationDto> CreateAsync(CreateCategoryTranslationDto dto)
        {
            var data = _mapper.Map<CategoryTranslation>(dto);
            var newData = await _command.CreateAsync(data);
            await _save.SaveChangesAsync();
            _memory.Set(CacheKey, newData, TimeSpan.FromMinutes(30));
            return _mapper.Map<CategoryTranslationDto>(newData);
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

        public async Task<ICollection<CategoryTranslationDto>> GetAllTranslationsAsync()
        {
            if(_memory.TryGetValue(CacheKey, out var cachedDict)) 
                return _mapper.Map<ICollection<CategoryTranslationDto>>(cachedDict);
            var allData = await _query.GetAllAsync().ToListAsync();
            _memory.Set(CacheKey, allData, TimeSpan.FromMinutes(30));
            return _mapper.Map<ICollection<CategoryTranslationDto>>(allData);
        }

        public async Task<CategoryTranslationDto> GetByIdAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if(dataId == null)
                throw new ArgumentNullException(nameof(dataId),$"Id tapilmadi. Id:{id}");
            return _mapper.Map<CategoryTranslationDto>(dataId);
        }
    }
}
