
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.Headbanner;
using Oxu.Domain.DTOs.News;
using Oxu.Domain.Entities;
using Oxu.Domain.IRepositories;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Persistance.UnitOfWorks;
using System;

namespace Oxu.Infrastructure.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepo _command;
        private readonly IQueryRepository<News> _query;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _save;
        private readonly IMemoryCache _memory;
        private readonly string cacheKey = "NewsCacheKey";

        public NewsService(IMemoryCache memoryCache, IUnitOfWork save, IMapper mapper, IQueryRepository<News> query, INewsRepo command)
        {
            _memory = memoryCache;
            _save = save;
            _mapper = mapper;
            _query = query;
            _command = command;
        }

        public async Task<NewsDto> CreateAsync(CreateNewsDto dto)
        {
           var data = _mapper.Map<News>(dto);
           var newData =await _command.CreateAsync(data);
           await _save.SaveChangesAsync();
           _memory.Set(cacheKey, newData, TimeSpan.FromMinutes(30));
           return _mapper.Map<NewsDto>(newData);
        }

        public async Task DeleteAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if (dataId == null)
                throw new ArgumentNullException(nameof(dataId), $"Silmek mumkun olmadi xeberi .Id:{id}");
            await _command.DeleteAsync(dataId);
            await _save.SaveChangesAsync();
            _memory.Remove(cacheKey);
        }

        public async Task<ICollection<NewsDto>> GetAllAsync()
        {
            if(_memory.TryGetValue(cacheKey,out ICollection<News>? cachedDict))
                return _mapper.Map<ICollection<NewsDto>>(cachedDict);
            var data = await _query.GetAllAsync().ToListAsync();
            _memory.Set(cacheKey, data, TimeSpan.FromMinutes(30));
            return _mapper.Map<ICollection<NewsDto>>(data);
        }

        public async Task<NewsDto> GetByIdAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if (dataId == null)
                throw new ArgumentNullException(nameof(dataId), $"Silmek mumkun olmadi xeberi .Id:{id}");
            return _mapper.Map<NewsDto>(dataId);
        }
    }
}
