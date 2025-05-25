
using Oxu.Domain.Entities;
using Oxu.Domain.IRepositories;
using Oxu.Persistance.Repositories.Generics;
using Oxu.Presentation.Context;

namespace Oxu.Persistance.Repositories
{
    public class TagTranslationRepo : CommandRepository<TagTranslation>, ITagTranslationRepo
    {
        public TagTranslationRepo(OxuDbContext context) : base(context)
        {
        }
    }
}
