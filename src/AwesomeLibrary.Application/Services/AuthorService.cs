using AutoMapper;
using AwesomeLibrary.Application.Resources.Authors.Models;
using AwesomeLibrary.Application.Services.Interfaces;
using AwesomeLibrary.Domain.Entities;
using AwesomeLibrary.Persistance;

namespace AwesomeLibrary.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AwesomeLibraryDbContext _context;
        private readonly IMapper _mapper;

        public AuthorService(AwesomeLibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AuthorGetDto> CreateAuthor(AuthorPostDto author, CancellationToken cancellationToken)
        {
            var authorToAdd = _mapper.Map<Author>(author);

            await _context.Authors.AddAsync(authorToAdd, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            var authorToReturn = _mapper.Map<AuthorGetDto>(authorToAdd);
            return authorToReturn;
        }
    }
}
