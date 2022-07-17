using AutoMapper;
using AwesomeLibrary.Application.Resources.Books.Models;
using AwesomeLibrary.Application.Resources.Books.Requests;
using AwesomeLibrary.Application.Resources.BooksAuthors.Models;
using AwesomeLibrary.Domain.Entities;

namespace AwesomeLibrary.Application.Resources.Books
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateRequest, Book>();
            CreateMap<Book, BookGetDto>();

            CreateMap<Book, BookWithAuthorsGetDto>()
                .ForMember(t => t.Authors, o => o.MapFrom(s => s.BooksAuthors.Select(ba => ba.Author)));
            CreateMap<BookPostDto, Book>();
        }
    }
}
