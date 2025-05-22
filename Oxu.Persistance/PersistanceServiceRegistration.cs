
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Oxu.Domain.IRepositories;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Persistance.Mapper;
using Oxu.Persistance.Repositories;
using Oxu.Persistance.Repositories.Generics;
using Oxu.Persistance.UnitOfWorks;
using Oxu.Presentation.Context;

namespace Oxu.Persistance
{
    public static class PersistanceServiceRegistration
    {
        public static void AddPersistance(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<OxuDbContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("env"));
            });
            services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
        public static void AddDIRepositories(this IServiceCollection services)
        {
            #region Generics
            services.AddScoped(typeof(IQueryRepository<>), typeof(QueryRepository<>));
            services.AddScoped(typeof(ICommandRepository<>), typeof(CommandRepository<>));
            #endregion

            #region Repositories
            services.AddScoped<IHeadBannerRepo, HeadBannerRepo>();
            services.AddScoped<IHeadBannerTranslationRepo, HeadBannerTranslationRepo>();
            #endregion

            #region UnitOfWorks
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            #endregion
        }
    }
}
