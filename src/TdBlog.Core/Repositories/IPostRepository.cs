using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TdBlog.Core.Domain.Content;
using TdBlog.Core.SeedWorks;

namespace TdBlog.Core.Repositories
{
    public interface IPostRepository: IRepository<Post,Guid>
    {
        Task<List<Post>> GetPopularPostsAsync(int count);
    }
}
