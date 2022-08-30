using Blog.Core.Models;

namespace Blog.Core.Repositories
{
    public interface IPostRepository : IGenericRepository<Post>
    {
        Task<Post> GetPostInDetail(int postId);

        Task<(List<Post>, int)> GetPostsWithPaged(int page, int pageSize);
    }
}
