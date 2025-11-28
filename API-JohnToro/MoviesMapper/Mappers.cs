using API_JohnToro.DAL.Models.Dtos;
using API_JohnToro.DAL.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoMapper;

namespace API_JohnToro.MoviesMapper
{
    public class Mappers : Profile
    {
        public Mappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryCreateUpdateDto>().ReverseMap();
            CreateMap<Category, MovieDto>().ReverseMap();
            CreateMap<Category, MovieCreateUpdateDto>().ReverseMap();
        }
    }
}
