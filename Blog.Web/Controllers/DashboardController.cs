using AutoMapper;
using Blog.Core.DTOs;
using Blog.Core.Models;
using Blog.Web.Models.ViewModels;
using Blog.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;

namespace Blog.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly PostApiService _postApiService;
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;

        public DashboardController(PostApiService postApiService, CategoryApiService categoryApiService, IMapper mapper, IFileProvider fileProvider)
        {
            _postApiService = postApiService;
            _categoryApiService = categoryApiService;
            _mapper = mapper;
            _fileProvider = fileProvider;
        }


        public async Task<IActionResult> Index()
        {
            ViewBag.posts = await _postApiService.GetPostsAsync();

            return View();
        }

        // Get Post Create Page
        public async Task<IActionResult> CreatePost()
        {
            ViewBag.categories = await _categoryApiService.GetAll();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(PostCreateViewModel post)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.categories = await _categoryApiService.GetAll();

                return RedirectToAction("Index", "Author", post);
            }

            // Save Photo
            var photoName = Guid.NewGuid().ToString();
            SavePhoto(post.Photo, photoName);

            var newPost = _mapper.Map<PostCreateDto>(post);

            newPost.PhotoName = $"{photoName}{Path.GetExtension(post.Photo.FileName)}";

            await _postApiService.SaveAsync(newPost);

            return RedirectToAction("Index", "Dashboard");

        }

        // Get Post Update Page
        public async Task<IActionResult> UpdatePost(int id)
        {
            ViewBag.post = await _postApiService.GetByIdAsync(id);

            ViewBag.categories = await _categoryApiService.GetAll();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(PostUpdateViewModel post)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.categories = await _categoryApiService.GetAll();

                return RedirectToAction("Index", "Author", post);
            }

            // Save Photo
            var photoName = Guid.NewGuid().ToString();
            SavePhoto(post.Photo, photoName);

            var newPost = _mapper.Map<PostUpdateDto>(post);

            newPost.PhotoName = $"{photoName}{Path.GetExtension(post.Photo.FileName)}";

            await _postApiService.UpdateAsync(newPost);

            return RedirectToAction("Index", "Dashboard");
        }



        public async Task<IActionResult> Remove(int id)
        {
            await _postApiService.RemoveAsync(id);

            return RedirectToAction("Index", "Dashboard");
        }

        private async void SavePhoto(IFormFile photo, string fileName)
        {
            if (photo != null && photo.Length > 0)
            {
                var root = _fileProvider.GetDirectoryContents("wwwroot");
                var picturesDirectory = root.Single(x => x.Name == "pictures");

                var extensionOfPhoto = Path.GetExtension(photo.FileName);
                var path = Path.Combine(picturesDirectory.PhysicalPath, fileName + extensionOfPhoto);

                using var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream);
            }
        }
    }
}
