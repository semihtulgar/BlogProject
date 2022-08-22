using AutoMapper;
using BlogProject.Models;
using BlogProject.Models.ViewModels;

namespace BlogProject.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Post, PostViewModel>().ReverseMap();
            CreateMap<Post, PostCreateViewModel>().ReverseMap();
            CreateMap<Post, PostUpdateViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
        }
        
    }
}
