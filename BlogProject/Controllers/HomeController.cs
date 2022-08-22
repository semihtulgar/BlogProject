using AutoMapper;
using BlogProject.Models;
using BlogProject.Models.ViewModels;
using BlogProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IPostRepository postRepository, IMapper mapper)
        {
            _logger = logger;
            _postRepository = postRepository;
            _mapper = mapper;
        }

        public IActionResult Index(int page = 1)
        {
            //var posts = _mapper.Map<List<PostViewModel>>(_postRepository.GetAll());

            var pageSize = 3;
            var postList = _mapper.Map<List<PostViewModel>>(_postRepository.GetPostsWithPaged(page, pageSize).Item1);
            var totalCount = _postRepository.GetPostsWithPaged(page, pageSize).Item2;
            int totalPage = (int)Math.Ceiling((decimal)totalCount / pageSize);
            ViewBag.totalPage = totalPage;
            ViewBag.page = page;
            return View(postList);

        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
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