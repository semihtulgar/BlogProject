using Blog.Core.DTOs;
using Blog.Core.Models;

namespace Blog.Web.Services
{
    public class CategoryApiService
    {

        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CategoriesWithPostCount>> GetCategoriesWithPostCount()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CategoriesWithPostCount>>>("Categories/GetCategoriesWithPostCount");

            return response.Data;
        }

        public async Task<CategoryWithPostsDto> GetCategoryByIdWithProductsAsync(int categoryid)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CategoryWithPostsDto>>($"Categories/GetCategoryByIdWithProducts/{categoryid}");

            return response.Data;
        }

        public async Task<List<CategoryDto>> GetAll()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<CategoryDto>>>("Categories");

            return response.Data;
        }


    }
}
