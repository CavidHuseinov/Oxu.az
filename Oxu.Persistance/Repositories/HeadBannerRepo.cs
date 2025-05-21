
using Oxu.Domain.Entities;
using Oxu.Domain.IRepositories;
using Oxu.Domain.IRepositories.Generics;
using Oxu.Persistance.Repositories.Generics;
using Oxu.Presentation.Context;

namespace Oxu.Persistance.Repositories
{
    public class HeadBannerRepo : CommandRepository<HeadBanner>, IHeadBannerRepo
    {
        public HeadBannerRepo(OxuDbContext context) : base(context)
        {
        }
    }
}
