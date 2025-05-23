
using Oxu.Domain.Entities;
using Oxu.Domain.IRepositories;
using Oxu.Persistance.Repositories.Generics;
using Oxu.Presentation.Context;

namespace Oxu.Persistance.Repositories
{
    public class NewsTranslationRepo : CommandRepository<NewsTranslation>, INewsTranslationRepo
    {
        public NewsTranslationRepo(OxuDbContext context) : base(context)
        {
        }
    }
}
