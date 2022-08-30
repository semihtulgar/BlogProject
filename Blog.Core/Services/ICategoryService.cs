using Blog.Core.DTOs;
using Blog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        // İlgili kategoriye sahip postları çeker
        Task<CustomResponseDto<CategoryWithPostsDto>> GetCategoryByIdWithProductsAsync(int categoryId);

        Task<CustomResponseDto<List<CategoriesWithPostCount>>> GetCategoriesWithPostCount();
    }
}
