
using AutoMapper;
using Oxu.Domain.DTOs.Category;
using Oxu.Domain.DTOs.CategoryTranslation;
using Oxu.Domain.DTOs.Headbanner;
using Oxu.Domain.DTOs.HeadbannerTranslation;
using Oxu.Domain.DTOs.News;
using Oxu.Domain.DTOs.NewsAndTag;
using Oxu.Domain.DTOs.NewsTranslation;
using Oxu.Domain.DTOs.Reactions;
using Oxu.Domain.DTOs.Tag;
using Oxu.Domain.Entities;

namespace Oxu.Persistance.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Headbanner
            CreateMap<CreateHeadBannerDto, HeadBanner>().ReverseMap();
            CreateMap<HeadBannerDto, HeadBanner>().ReverseMap();
            #endregion

            #region HeadbannerTranslation
            CreateMap<CreateHeadbannerTranslationDto, HeadBannerTranslation>().ReverseMap();
            CreateMap<HeadbannerTranslationDto, HeadBannerTranslation>().ReverseMap();
            #endregion

            #region News 
            CreateMap<CreateNewsDto, News>().ReverseMap();
            CreateMap<NewsDto, News>().ReverseMap();
            #endregion

            #region NewsTranslation
            CreateMap<NewsTranslation, CreateNewsTranslationDto>().ReverseMap();
            CreateMap<NewsTranslation, NewsTranslationDto>().ReverseMap();
            #endregion

            #region Reactions
            CreateMap<CreateReactionsDto, Reactions>().ReverseMap();
            CreateMap<ReactionsDto, Reactions>().ReverseMap();
            #endregion

            #region Category
            CreateMap<Category, CreateCategoryDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            #endregion

            #region CategoryTranslation
            CreateMap<CategoryTranslation, CategoryTranslationDto>().ReverseMap();
            CreateMap<CategoryTranslation, CreateCategoryTranslationDto>().ReverseMap();
            #endregion

            #region Tag
            CreateMap<CreateTagDto, Tag>().ReverseMap();
            CreateMap<TagDto, Tag>().ReverseMap();
            #endregion

            #region NewsAndTag
            CreateMap<NewsAndTag,CreateNewsAndTagDto>().ReverseMap();
            CreateMap<NewsAndTag, NewsAndTagDto>().ReverseMap();
            #endregion
        }
    }
}
