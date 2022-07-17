using AutoMapper;
using AwesomeLibrary.Application.Resources.BooksAuthors.Models;
using AwesomeLibrary.Domain.Entities;

namespace AwesomeLibrary.Application.Resources.BooksAuthors
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BookAuthorDto, BookAuthor>();
        }
    }
}
