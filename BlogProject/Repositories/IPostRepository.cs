using BlogProject.Models;
using BlogProject.Models.ViewModels;
using System.Linq.Expressions;

namespace BlogProject.Repositories
{
    public interface IPostRepository
    {
        List<Post> GetAll();

        Post Create(Post post);

        void Update(Post post);

        Post GetById(int id);

        void Delete(int id);

        bool Any(Expression<Func<Post, bool>> predicate);

        List<Category> GetCategories();

        (List<Post>, int) GetPostsWithPaged(int page, int pageSize);
    }
}
