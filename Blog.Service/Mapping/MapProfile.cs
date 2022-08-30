using AutoMapper;
using Blog.Core.DTOs;
using Blog.Core.Models;

namespace Blog.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Post, PostInDetailDto>().ReverseMap();
            CreateMap<Post, PostDto>().ReverseMap();
            CreateMap<Post, PostUpdateDto>().ReverseMap();
            CreateMap<Post, PostCreateDto>().ReverseMap();
            
            CreateMap<Category, CategoryWithPostsDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            CreateMap<Category, CategoriesWithPostCount>().ReverseMap();


            CreateMap<Comment, CommentCreateDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();

        }


    }
}
