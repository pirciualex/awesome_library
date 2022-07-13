using AutoMapper;
using AwesomeLibrary.API.Models;
using AwesomeLibrary.Domain.Entities;

namespace AwesomeLibrary.Application.Requests.Books
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateRequest, Book>();
            CreateMap<Book, BookGetDto>();
            //CreateMap<Book, BookPostDto>();
        }
    }
}
