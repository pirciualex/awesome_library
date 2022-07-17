using AutoMapper;
using AwesomeLibrary.Application.Resources.Books.Models;
using AwesomeLibrary.Application.Services.Interfaces;
using AwesomeLibrary.Common.Exceptions;
using AwesomeLibrary.Persistance;
using Microsoft.EntityFrameworkCore;

namespace AwesomeLibrary.Application.Services
{
    public class BookService : IBookService
    {
        private readonly AwesomeLibraryDbContext _context;
        private readonly IMapper _mapper;

        public BookService(AwesomeLibraryDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BookWithAuthorsDto> GetBookWithAuthors(Guid bookId, CancellationToken cancellationToken)
        {
            var book = await
                _context.Books
                .Include(b => b.BooksAuthors)
                .ThenInclude(ba => ba.Author)
                .SingleOrDefaultAsync(b => b.Id == bookId, cancellationToken);
            if (book == default)
            {
                throw new NotFoundException("The book you requested was not found");
            }

            return _mapper.Map<BookWithAuthorsDto>(book);
        }
    }
}
