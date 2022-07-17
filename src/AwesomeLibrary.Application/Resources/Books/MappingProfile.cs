using AutoMapper;
using AwesomeLibrary.Application.Resources.Books.Models;
using AwesomeLibrary.Application.Resources.Books.Requests;
using AwesomeLibrary.Domain.Entities;

namespace AwesomeLibrary.Application.Resources.Books
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateRequest, Book>();
            CreateMap<Book, BookGetDto>();

            CreateMap<Book, BookWithAuthorDto>()
                .ForMember(t => t.Authors, o => o.MapFrom(s => s.BooksAuthors.Select(ba => ba.Author)));
            //CreateMap<Book, BookPostDto>();
        }
    }
}
