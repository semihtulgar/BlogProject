using AutoMapper;
using Blog.Core.Models;
using Blog.Web.Models.ViewModels;
using Blog.Web.Models;
using Blog.Core.DTOs;
using System.Drawing;

namespace Blog.Web.Mappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<PostCreateDto, PostCreateViewModel>().ReverseMap();
            CreateMap<PostUpdateDto, PostUpdateViewModel>().ReverseMap();
        }
    }
}
