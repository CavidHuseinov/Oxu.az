
using AutoMapper;
using Oxu.Domain.DTOs.Headbanner;
using Oxu.Domain.Entities;

namespace Oxu.Persistance.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Headbanner
            CreateMap<CreateHeadBannerDto,HeadBanner>().ReverseMap();
            CreateMap<HeadBannerDto, HeadBanner>().ReverseMap();
            #endregion
        }
    }
}
