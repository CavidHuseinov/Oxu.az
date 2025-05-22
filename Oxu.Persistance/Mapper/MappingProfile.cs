
using AutoMapper;
using Oxu.Domain.DTOs.Headbanner;
using Oxu.Domain.DTOs.HeadbannerTranslation;
using Oxu.Domain.DTOs.News;
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

            #region HeadbannerTranslation
            CreateMap<CreateHeadbannerTranslationDto, HeadBannerTranslation>().ReverseMap();
            CreateMap<HeadbannerTranslationDto, HeadBannerTranslation>().ReverseMap();
            #endregion

            #region News 
            CreateMap<CreateNewsDto,News>().ReverseMap();
            CreateMap<NewsDto,News>().ReverseMap();
            #endregion
        }
    }
}
