using AutoMapper;
using Blog.Core.DTOs;
using Blog.Web.Models;
using Blog.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Blog.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PostApiService _postApiService;
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, PostApiService postApiService, CategoryApiService categoryApiService, IMapper mapper)
        {
            _logger = logger;
            _postApiService = postApiService;
            _categoryApiService = categoryApiService;
            _mapper = mapper;
        }


        //public async Task<IActionResult> Index()
        //{
        //    ViewBag.posts = await _postApiService.GetPostsAsync();
        //    ViewBag.categoriesWithCount = await _categoryApiService.GetCategoriesWithPostCount();

        //    return View();
        //}

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.categoriesWithCount = await _categoryApiService.GetCategoriesWithPostCount();

            var pageSize = 3;
            var postPagedDto = await _postApiService.GetPostsWithPaged(page, pageSize);

            ViewBag.posts = postPagedDto.Posts;

            ViewBag.totalPage = (int)Math.Ceiling((decimal)postPagedDto.TotalCount / pageSize);

            ViewBag.page = page;

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}