
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.Headbanner;
using Oxu.Domain.Entities;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Domain.IRepositories;
using Oxu.Persistance.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Oxu.Domain.DTOs.HeadbannerTranslation;

namespace Oxu.Infrastructure.Services
{
    public class HeadBannerTranslationService : IHeadbannerTranslationService
    {
        private readonly IQueryRepository<HeadBannerTranslation> _query;
        private readonly IHeadBannerTranslationRepo _command;
        private readonly IUnitOfWork _save;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memory;
        private readonly string CacheKey = "HeadbannerAndHeadbannerTranslationCache";

        public HeadBannerTranslationService(IMemoryCache memory, IMapper mapper, IUnitOfWork save, IHeadBannerTranslationRepo command, IQueryRepository<HeadBannerTranslation> query)
        {
            _memory = memory;
            _mapper = mapper;
            _save = save;
            _command = command;
            _query = query;
        }

        public async Task<HeadbannerTranslationDto> CreateAsync(CreateHeadbannerTranslationDto dto)
        {
            var data = _mapper.Map<HeadBannerTranslation>(dto);
            var newData = await _command.CreateAsync(data);
            await _save.SaveChangesAsync();
            _memory.Set(CacheKey, newData, TimeSpan.FromMinutes(30));
            return _mapper.Map<HeadbannerTranslationDto>(newData);
        }

        public async Task DeleteAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if (dataId == null) throw new ArgumentNullException(nameof(dataId), $"Headbanner Id'si tapilmadi.Id:{id}");
            await _command.DeleteAsync(dataId);
            await _save.SaveChangesAsync();
            _memory.Remove(CacheKey);
        }

        public async Task<ICollection<HeadbannerTranslationDto>> GetAllAsync()
        {
            if (_memory.TryGetValue(CacheKey, out var cachedDict))
                return _mapper.Map < ICollection<HeadbannerTranslationDto>>(cachedDict);
            var dataAll = await _query.GetAllAsync().ToListAsync();
            _memory.Set(CacheKey, dataAll, TimeSpan.FromMinutes(30));
            return _mapper.Map<ICollection<HeadbannerTranslationDto>>(dataAll);
        }

        public async Task<HeadbannerTranslationDto> GetByIdAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if (dataId == null) throw new ArgumentNullException(nameof(dataId), $"Headbanner Id'si tapilmadi.Id:{id}");
            return _mapper.Map<HeadbannerTranslationDto>(dataId);
        }
    }
}
