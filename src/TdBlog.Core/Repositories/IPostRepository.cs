using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TdBlog.Core.Domain.Content;
using TdBlog.Core.Models;
using TdBlog.Core.Models.Content;
using TdBlog.Core.SeedWorks;

namespace TdBlog.Core.Repositories
{
    public interface IPostRepository: IRepository<Post,Guid>
    {
        Task<List<Post>> GetPopularPostsAsync(int count);

        Task<PagedResult<PostInListDto>> GetPostsPagingAsync(string? keyword, Guid? categoryId, int pageIndex = 1, int pageSize = 10);
    }
}
