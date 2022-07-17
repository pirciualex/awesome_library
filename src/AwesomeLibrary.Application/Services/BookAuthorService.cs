using AutoMapper;
using AwesomeLibrary.Application.Resources.BooksAuthors.Models;
using AwesomeLibrary.Application.Services.Interfaces;
using AwesomeLibrary.Domain.Entities;
using AwesomeLibrary.Persistance;

namespace AwesomeLibrary.Application.Services
{
    public class BookAuthorService : IBookAuthorService
    {
        private readonly AwesomeLibraryDbContext _context;
        private readonly IMapper _mapper;

        public BookAuthorService(AwesomeLibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookAuthorDto> LinkBookToAuthor(BookAuthorDto bookAuthor, CancellationToken cancellationToken)
        {
            await _context.BooksAuthors.AddAsync(_mapper.Map<BookAuthor>(bookAuthor));
            await _context.SaveChangesAsync();
            return bookAuthor;
        }
    }
}
