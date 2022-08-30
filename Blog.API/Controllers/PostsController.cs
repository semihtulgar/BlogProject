using AutoMapper;
using Blog.API.Filters;
using Blog.Core.DTOs;
using Blog.Core.Models;
using Blog.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

namespace Blog.API.Controllers
{

    public class PostsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IPostService _service;

        public PostsController(IPostService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET - api/posts/GetPostInDetail/{id}
        [HttpGet("[action]/{postId}")]
        public async Task<IActionResult> GetPostInDetail(int postId)
        {
            return CreateActionResult(await _service.GetPostInDetail(postId));
        }

        [HttpGet("[action]/pageSize/{pageSize}/page/{page}")]
        public async Task<IActionResult> GetPostsWithPaged(int page, int pageSize)
        {
            var posts = await _service.GetPostsWithPaged(page, pageSize);

            return CreateActionResult(posts);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> All()
        {
            var posts = await _service.GetAllAsync();

            var postsDtos = _mapper.Map<List<PostDto>>(posts.ToList());

            return CreateActionResult(CustomResponseDto<List<PostDto>>.Success(200, postsDtos));
        }

        [ServiceFilter(typeof(NotFoundFilter<Post>))]
        // GET - /api/posts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _service.GetByIdAsync(id);

            var postDto = _mapper.Map<PostDto>(post);

            return CreateActionResult(CustomResponseDto<PostDto>.Success(200, postDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PostCreateDto postCreateDto)
        {
            var post = await _service.AddAsync(_mapper.Map<Post>(postCreateDto));

            var postDto = _mapper.Map<PostDto>(post);

            return CreateActionResult(CustomResponseDto<PostDto>.Success(201, postDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(PostUpdateDto postUpdateDto)
        {
            await _service.UpdateAsync(_mapper.Map<Post>(postUpdateDto));
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<Post>))]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var post = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(post);

            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }
    }
}
