using Blog.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Services
{
    public class CommentApiService
    {

        private readonly HttpClient _httpClient;

        public CommentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CommentDto> SaveAsync(CommentCreateDto newComment)
        {
            var response = await _httpClient.PostAsJsonAsync("comments", newComment);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<CommentDto>>();

            return responseBody.Data;

        }

    }
}
