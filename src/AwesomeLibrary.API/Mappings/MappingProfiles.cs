using AutoMapper;
using AwesomeLibrary.API.Models;
using AwesomeLibrary.Domain.Entities;

namespace AwesomeLibrary.API.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BookPostDto, Book>();
            CreateMap<Book, BookGetDto>();
            CreateMap<Book, BookPostDto>();

            CreateMap<AuthorPostDto, Author>();
            CreateMap<Author, AuthorGetDto>()
                .ForMember(t => t.FullName, o => o.MapFrom(s => $"{s.FirstName} {s.LastName}"));
            CreateMap<Author, AuthorPostDto>();
        }
    }
}
