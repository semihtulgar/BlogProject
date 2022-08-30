using AutoMapper;
using Blog.Core.DTOs;
using Blog.Core.Models;
using Blog.Core.Repositories;
using Blog.Core.Services;
using Blog.Core.UnitOfWorks;

namespace Blog.Service.Services
{
    public class PostService : Service<Post>, IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IGenericRepository<Post> repository, IUnitOfWork unitOfWork, IPostRepository postRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponseDto<PostInDetailDto>> GetPostInDetail(int postId)
        {
            var post = await _postRepository.GetPostInDetail(postId);

            var postInDetailDto = _mapper.Map<PostInDetailDto>(post);

            return CustomResponseDto<PostInDetailDto>.Success(200, postInDetailDto);

        }

        public async Task<CustomResponseDto<PostPagedDto>> GetPostsWithPaged(int page, int pageSize)
        {
            var (postsList, totalCount) = await _postRepository.GetPostsWithPaged(page, pageSize);

            var postListDto = _mapper.Map<List<PostDto>>(postsList);

            var pagedPostDto = new PostPagedDto() { Posts = postListDto, TotalCount = totalCount };

            return CustomResponseDto<PostPagedDto>.Success(200, pagedPostDto);
        }
    }
}
