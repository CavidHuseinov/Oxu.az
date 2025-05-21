

using Oxu.Presentation.Context;

namespace Oxu.Persistance.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OxuDbContext _context;

        public UnitOfWork(OxuDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellation = default)
        {
            return await _context.SaveChangesAsync(cancellation);
        }
    }
}
