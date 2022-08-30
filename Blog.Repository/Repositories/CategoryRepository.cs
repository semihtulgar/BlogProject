using Blog.Core.DTOs;
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
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(BlogDbContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryByIdWithPostsAsync(int categoryId)
        {
            return await _context.Categories.Include(c => c.Posts).Where(c => c.CategoryId == categoryId).SingleOrDefaultAsync();
        }

        public async Task<List<Category>> GetCategoriesWithPostCount()
        {
            return await _context.Categories.Include(c => c.Posts).ToListAsync();
        }
    }
}
