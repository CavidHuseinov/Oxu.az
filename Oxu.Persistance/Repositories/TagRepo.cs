
using Oxu.Domain.Entities;
using Oxu.Domain.IRepositories;
using Oxu.Persistance.Repositories.Generics;
using Oxu.Presentation.Context;

namespace Oxu.Persistance.Repositories
{
    public class TagRepo : CommandRepository<Tag>, ITagRepo
    {
        public TagRepo(OxuDbContext context) : base(context)
        {
        }
    }
}
