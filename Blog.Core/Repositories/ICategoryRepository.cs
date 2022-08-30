using Blog.Core.DTOs;
using Blog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repositories
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        // İlgili kategoriye sahip bütün postları alır
        Task<Category> GetCategoryByIdWithPostsAsync(int categoryId);

        Task<List<Category>> GetCategoriesWithPostCount();
    }
}
