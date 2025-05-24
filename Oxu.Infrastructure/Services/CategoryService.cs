
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.Category;
using Oxu.Domain.Entities;
using Oxu.Domain.IRepositories;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Persistance.UnitOfWorks;

namespace Oxu.Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepo _command;
        private readonly IQueryRepository<Category> _query;
        private readonly IUnitOfWork _save;
        private readonly IMemoryCache _memory;
        private readonly string CacheKey = "NewsAndCategoryAndTagCacheKey";
        public CategoryService(IMapper mapper, ICategoryRepo command, IQueryRepository<Category> query, IUnitOfWork save, IMemoryCache memory)
        {
            _mapper = mapper;
            _command = command;
            _query = query;
            _save = save;
            _memory = memory;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var data = _mapper.Map<Category>(dto);
            var newData = await _command.CreateAsync(data);
            await _save.SaveChangesAsync();
            _memory.Set(CacheKey, newData, TimeSpan.FromMinutes(30));
            return _mapper.Map<CategoryDto>(newData);
        }

        public async Task DeleteAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if (dataId == null)
                throw new ArgumentNullException(nameof(dataId), $"Id tapilmadi. Id: {dataId}");
            await _command.DeleteAsync(dataId);
            _memory.Remove(CacheKey);
            await _save.SaveChangesAsync();
        }

        public async Task<ICollection<CategoryDto>> GetAllAsync()
        {
            if (_memory.TryGetValue(CacheKey, out var cachedDict))
                return _mapper.Map<ICollection<CategoryDto>>(cachedDict);
            var allData = await _query.GetAllAsync(include:q=>q.
            Include(x=>x.CategoryTranslations)).ToListAsync();
            _memory.Set(CacheKey, allData, TimeSpan.FromMinutes(30));
            return _mapper.Map<ICollection<CategoryDto>>(allData);
        }

        public async Task<CategoryDto> GetByIdAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if(dataId == null)
                throw new ArgumentNullException(nameof(dataId),$"Id tapilmadi. Id: {dataId}");
            return _mapper.Map<CategoryDto>(dataId);
        }
    }
}
