using AutoMapper;
using TdBlog.Core.Repositories;
using TdBlog.Core.SeedWorks;
using TdBlog.Data.Repositories;

namespace TdBlog.Data.SeedWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TdBlogContext _context;

        public UnitOfWork(TdBlogContext context, IMapper mapper)
        {
            _context = context;

            Posts = new PostRepository(context, mapper);
        }

        public IPostRepository Posts { get;private set; }


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
