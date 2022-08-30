using Blog.Core.DTOs;
using Blog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services
{
    public interface IPostService : IService<Post>
    {
        // Post'un kategorisini ve yorumlarını getirir
        Task<CustomResponseDto<PostInDetailDto>> GetPostInDetail(int postId);

        Task<CustomResponseDto<PostPagedDto>> GetPostsWithPaged(int page, int pageSize);
    }
}
