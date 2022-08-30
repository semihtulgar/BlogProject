using Blog.Core.Models;
using Blog.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Repository.Repositories
{
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(BlogDbContext context) : base(context)
        {
        }

        public async Task<Post> GetPostInDetail(int postId)
        {
            return await _context.Posts.Include(p => p.Category).Include(p => p.Comments).Where(p => p.PostId == postId).FirstOrDefaultAsync();
        }

        public async Task<(List<Post>, int)> GetPostsWithPaged(int page, int pageSize)
        {
            var posts = await _context.Posts.OrderByDescending(p => p.PostId).ToListAsync();

            var totalPostCount = posts.Count;

            var listedPost = posts.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            return (listedPost, totalPostCount);
        }

    }
}
