
using Oxu.Domain.Entities;
using Oxu.Domain.IRepositories;
using Oxu.Persistance.Repositories.Generics;
using Oxu.Presentation.Context;

namespace Oxu.Persistance.Repositories
{
    public class HeadBannerTranslationRepo : CommandRepository<HeadBannerTranslation>, IHeadBannerTranslationRepo
    {
        public HeadBannerTranslationRepo(OxuDbContext context) : base(context)
        {
        }
    }
}
