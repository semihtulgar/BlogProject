using AutoMapper;
using Blog.Core.DTOs;
using Blog.Web.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly PostApiService _postApiService;
        private readonly CategoryApiService _categoryApiService;
        private readonly CommentApiService _commentApiService;
        private readonly IMapper _mapper;

        public PostController(PostApiService postApiService, CategoryApiService categoryApiService, IMapper mapper, CommentApiService commentApiService)
        {
            _postApiService = postApiService;
            _categoryApiService = categoryApiService;
            _mapper = mapper;
            _commentApiService = commentApiService;
        }



        public async Task<IActionResult> Index(int id)
        {
            ViewBag.postInDetail = await _postApiService.GetPostInDetail(id);

            return View();
        }

        public async Task<IActionResult> PostOfCategory(int id)
        {
            ViewBag.posts = await _categoryApiService.GetCategoryByIdWithProductsAsync(id);
            ViewBag.categoriesWithCount = await _categoryApiService.GetCategoriesWithPostCount();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentCreateDto comment, int postId)
        {
            var commentDto = await _commentApiService.SaveAsync(comment);
            return RedirectToAction("Index", "Post", new { @id = postId });
        }


    }
}
