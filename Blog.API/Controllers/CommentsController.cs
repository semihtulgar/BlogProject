using AutoMapper;
using Blog.Core.DTOs;
using Blog.Core.Models;
using Blog.Core.Repositories;
using Blog.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
    public class CommentsController : CustomBaseController
    {
        private readonly ICommentService _service;
        private readonly IMapper _mapper;

        public CommentsController(ICommentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Save(CommentCreateDto commentCreateDto)
        {
            var comment = await _service.AddAsync(_mapper.Map<Comment>(commentCreateDto));

            var commentDto = _mapper.Map<CommentDto>(comment);

            return CreateActionResult(CustomResponseDto<CommentDto>.Success(201, commentDto));
        }

    }
}
