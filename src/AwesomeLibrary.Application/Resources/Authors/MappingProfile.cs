using AutoMapper;
using AwesomeLibrary.Application.Resources.Authors.Models;
using AwesomeLibrary.Domain.Entities;

namespace AwesomeLibrary.Application.Resources.Authors
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorGetDto>()
                .ForMember(t => t.FullName, o => o.MapFrom(s => $"{s.FirstName} {s.LastName}"));
            CreateMap<AuthorPostDto, Author>();
        }
    }
}
