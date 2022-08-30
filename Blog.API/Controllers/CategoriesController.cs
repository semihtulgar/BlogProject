using AutoMapper;
using Blog.API.Filters;
using Blog.Core.DTOs;
using Blog.Core.Models;
using Blog.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{

    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        // api/categories/GetCategoryByIdWithProductsAsync/id
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetCategoryByIdWithProductsAsync(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetCategoryByIdWithProductsAsync(categoryId));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategoriesWithPostCount()
        {
            return CreateActionResult(await _categoryService.GetCategoriesWithPostCount());
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAllAsync();

            var categoriesDto = _mapper.Map<List<CategoryDto>>(categories.ToList());

            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoriesDto));
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        // GET - /api/categories/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200, categoryDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryCreateDto)
        {
            var category = await _categoryService.AddAsync(_mapper.Map<Category>(categoryCreateDto));

            var categoryDto = _mapper.Map<CategoryDto>(category);

            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(201, categoryDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryUpdateDto categoryUpdateDto)
        {
            await _categoryService.UpdateAsync(_mapper.Map<Category>(categoryUpdateDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<Category>))]
        [HttpDelete]
        public async Task<IActionResult> Remove(int id)
        {
            var comment = await _categoryService.GetByIdAsync(id);

            await _categoryService.RemoveAsync(comment);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
