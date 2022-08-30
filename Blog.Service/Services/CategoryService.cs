using AutoMapper;
using Blog.Core.DTOs;
using Blog.Core.Models;
using Blog.Core.Repositories;
using Blog.Core.Services;
using Blog.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, ICategoryRepository categoryRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<CategoryWithPostsDto>> GetCategoryByIdWithProductsAsync(int categoryId)
        {
            var category = await _categoryRepository.GetCategoryByIdWithPostsAsync(categoryId);

            var categoryWithPostsDto = _mapper.Map<CategoryWithPostsDto>(category);

            return CustomResponseDto<CategoryWithPostsDto>.Success(200, categoryWithPostsDto);
        }

        public async Task<CustomResponseDto<List<CategoriesWithPostCount>>> GetCategoriesWithPostCount()
        {
            var categories = await _categoryRepository.GetCategoriesWithPostCount();

            var categoriesWithCountDto = _mapper.Map<List<CategoriesWithPostCount>>(categories);

            return CustomResponseDto<List<CategoriesWithPostCount>>.Success(200, categoriesWithCountDto);
        }

    }
}
