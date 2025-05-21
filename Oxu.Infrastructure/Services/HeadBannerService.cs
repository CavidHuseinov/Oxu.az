
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Oxu.Application.IServices;
using Oxu.Domain.DTOs.Headbanner;
using Oxu.Domain.Entities;
using Oxu.Domain.IRepositories;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Persistance.UnitOfWorks;

namespace Oxu.Infrastructure.Services
{
    public class HeadBannerService : IHeadBannerService
    {
        private readonly IQueryRepository<HeadBanner> _query;
        private readonly IHeadBannerRepo _command;
        private readonly IUnitOfWork _save;
        private readonly Mapper _mapper;
        private readonly IMemoryCache _memory;
        private readonly string CacheKey = "headBannerCache";

        public HeadBannerService(IMemoryCache memory, Mapper mapper, IUnitOfWork save, IHeadBannerRepo command, IQueryRepository<HeadBanner> query)
        {
            _memory = memory;
            _mapper = mapper;
            _save = save;
            _command = command;
            _query = query;
        }

        public async Task<HeadBannerDto> CreateAsync(CreateHeadBannerDto dto)
        {
            var data = _mapper.Map<HeadBanner>(dto);
            var newData = await _command.CreateAsync(data);
            await _save.SaveChangesAsync();
            _memory.Set(CacheKey, newData, TimeSpan.FromMinutes(30));
            return _mapper.Map<HeadBannerDto>(newData);
        }

        public async Task DeleteAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if (dataId == null) throw new ArgumentNullException($"Headbanner Id'si tapilmadi.Id:{id}");
            await _command.DeleteAsync(dataId);
            await _save.SaveChangesAsync();
            _memory.Remove(CacheKey);
        }

        public async Task<ICollection<HeadBannerDto>> GetAllAsync()
        {
            if(_memory.TryGetValue(CacheKey, out ICollection<HeadBanner>? cachedDict))
            {
                return _mapper.Map<ICollection<HeadBannerDto>>(cachedDict);
            }
            var allData = await _query.GetAllAsync().ToListAsync();
            return _mapper.Map<ICollection<HeadBannerDto>>(allData);
        }

        public async Task<HeadBannerDto> GetByIdAsync(Guid id)
        {
            var dataId = await _query.GetByIdAsync(id);
            if (dataId == null) throw new ArgumentNullException($"Headbanner Id'si tapilmadi.Id:{id}");
            return _mapper.Map<HeadBannerDto>(dataId);
        }
    }
}
