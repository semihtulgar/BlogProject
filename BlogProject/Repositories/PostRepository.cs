using BlogProject.Models;
using BlogProject.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BlogProject.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly BlogDbContext _context;

        public PostRepository(BlogDbContext context)
        {
            _context = context;
        }

        public bool Any(Expression<Func<Post, bool>> predicate)
        {
            return _context.Posts.Any(predicate);
        }

        public Post Create(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }

        public void Delete(int id)
        {
            var post = _context.Posts.Find(id);
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }

        public List<Post> GetAll()
        {
            return _context.Posts.Include(p => p.Category).ToList();
        }

        public Post? GetById(int id)
        {
            return _context.Posts.Include(p => p.Category).First(p => p.PostID == id);
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public void Update(Post post)
        {
            _context.Update(post);
            _context.SaveChanges();
        }

        public (List<Post>, int) GetPostsWithPaged(int page, int pageSize)
        {
            var posts = GetAll();
            int totalCount = posts.Count;
            var listedPosts = posts.Skip(pageSize * (page - 1)).Take(pageSize).ToList();
            return (listedPosts, totalCount);
        }
    }
}
