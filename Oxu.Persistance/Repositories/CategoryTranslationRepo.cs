
using Oxu.Domain.Entities;
using Oxu.Domain.IRepositories;
using Oxu.Persistance.Repositories.Generics;
using Oxu.Presentation.Context;

namespace Oxu.Persistance.Repositories
{
    public class CategoryTranslationRepo : CommandRepository<CategoryTranslation>, ICategoryTranslationRepo
    {
        public CategoryTranslationRepo(OxuDbContext context) : base(context)
        {
        }
    }
}
