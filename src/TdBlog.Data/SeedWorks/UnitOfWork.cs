using TdBlog.Core.SeedWorks;

namespace TdBlog.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TdBlogContext _context;

        public UnitOfWork(TdBlogContext context)
        {
            _context = context;
        }
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
