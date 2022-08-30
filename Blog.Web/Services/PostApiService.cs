using Blog.Core.DTOs;
using Blog.Web.Models;

namespace Blog.Web.Services
{
    public class PostApiService
    {

        private readonly HttpClient _httpClient;

        public PostApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PostDto>> GetPostsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<PostDto>>>("posts/all");

            return response.Data;
        }

        public async Task<PostDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<PostDto>>($"posts/{id}");

            return response.Data;
        }

        public async Task<PostDto> SaveAsync(PostCreateDto newPost)
        {
            var response = await _httpClient.PostAsJsonAsync("posts", newPost);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<PostDto>>();

            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(PostUpdateDto post)
        {
            var response = await _httpClient.PutAsJsonAsync("posts", post);

            if (!response.IsSuccessStatusCode) return false;

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"posts/{id}");

            return response.IsSuccessStatusCode;
        }

        public async Task<PostInDetailDto> GetPostInDetail(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<PostInDetailDto>>($"posts/getpostindetail/{id}");

            return response.Data;
        }

        public async Task<PostPagedDto> GetPostsWithPaged(int page, int pageSize)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<PostPagedDto>>($"posts/GetPostsWithPaged/pageSize/{pageSize}/page/{page}");

            return response.Data;
        }

    }
}
