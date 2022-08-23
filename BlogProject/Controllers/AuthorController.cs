

using AutoMapper;
using BlogProject.Models;
using BlogProject.Models.ViewModels;
using BlogProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.FileProviders;

namespace BlogProject.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;
        private readonly IFileProvider _fileProvider;

        public AuthorController(IPostRepository postRepository, IMapper mapper, IFileProvider fileProvider)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _fileProvider = fileProvider;
        }

        [HttpGet]
        public IActionResult Index()
        {

            #region Posts
            var posts = _postRepository.GetAll();
            #endregion

            var postTableViewModel = _mapper.Map<List<PostViewModel>>(posts);

            return View(new PostsTableViewModel()
            {
                Posts = postTableViewModel,
            });
        }

        public async void SavePhoto(IFormFile photo, string fileName)
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

        [HttpGet]
        public IActionResult Create()
        {
            #region Form Category
            var categories = _postRepository.GetCategories();
            ViewBag.categories = new SelectList(categories, "CategoryID", "CategoryName");
            #endregion

            return View();
        }

        [HttpPost]
        public IActionResult Create(PostCreateViewModel request)
        {
            if (!ModelState.IsValid)
            {
                var categories = _postRepository.GetCategories();

                ViewBag.categoryList = new SelectList(categories, "CategoryID", "CategoryName");

                return RedirectToAction("Index", "Author", request);
            }

            // Save Photo
            var photoName = Guid.NewGuid().ToString();
            SavePhoto(request.Photo, photoName);

            var newPost = _mapper.Map<Post>(request);

            newPost.PhotoName = $"{photoName}{Path.GetExtension(request.Photo.FileName)}";
            _postRepository.Create(newPost);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Delete(int id)
        {
            _postRepository.Delete(id);

            return RedirectToAction("Index", "Author");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            #region Form Category
            var categories = _postRepository.GetCategories();
            ViewBag.categories = new SelectList(categories, "CategoryID", "CategoryName");
            #endregion

            var postUpdateViewModel = _mapper.Map<PostUpdateViewModel>(_postRepository.GetById(id));

            return View(postUpdateViewModel);
        }

        [HttpPost]
        public IActionResult Update(PostUpdateViewModel request)
        {
            if (!ModelState.IsValid)
            {
                #region Form Category
                var categories = _postRepository.GetCategories();
                ViewBag.categories = new SelectList(categories, "CategoryID", "CategoryName");
                #endregion

                return View();
            }

            // Save Photo
            var photoName = Guid.NewGuid().ToString();
            SavePhoto(request.Photo, photoName);

            var updatedPost = _mapper.Map<Post>(request);

            updatedPost.PhotoName = $"{photoName}{Path.GetExtension(request.Photo.FileName)}";
            
            _postRepository.Update(updatedPost);

            return RedirectToAction("Index", "Author");
        }

        public IActionResult Detail(int id)
        {
            var post = _mapper.Map<PostViewModel>(_postRepository.GetById(id));

            return View(post);
        }
    }
}
