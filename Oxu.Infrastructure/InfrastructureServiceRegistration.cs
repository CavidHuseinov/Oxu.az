
using Microsoft.Extensions.DependencyInjection;
using Oxu.Application.IServices;
using Oxu.Infrastructure.Services;

namespace Oxu.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddMemoryCache();  
        }
        public static void AddDIServices(this IServiceCollection services)
        {
            services.AddScoped<IHeadBannerService, HeadBannerService>();
            services.AddScoped<IHeadbannerTranslationService, HeadBannerTranslationService>();
            services.AddScoped<IFileUploadService, FileUploadService>();
            services.AddScoped<INewsService, NewsService>();
            services.AddScoped<INewsTranslationService, NewsTranslationService>();
            services.AddScoped<IReactionService, ReactionService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryTranslationService, CategoryTranslationService>();
        }
    }
}
