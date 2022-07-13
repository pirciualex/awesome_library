using AutoMapper;
using AwesomeLibrary.API.Entities;
using AwesomeLibrary.API.Models;

namespace AwesomeLibrary.API.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<BookPostDto, Book>();
            CreateMap<Book, BookGetDto>();
            CreateMap<Book, BookPostDto>();

            CreateMap<Author, AuthorGetDto>()
                .ForMember(t => t.FullName, o => o.MapFrom(s => $"{s.FirstName} {s.LastName}"));
        }
    }
}
