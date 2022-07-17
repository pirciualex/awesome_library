using AutoMapper;
using AwesomeLibrary.Application.Resources.Books.Models;
using AwesomeLibrary.Application.Resources.BooksAuthors.Models;
using AwesomeLibrary.Application.Services.Interfaces;
using AwesomeLibrary.Domain.Entities;
using AwesomeLibrary.Persistance;
using MediatR;

namespace AwesomeLibrary.Application.Resources.BooksAuthors.Requests
{
    public class LinkBookToAuthorRequest : BookAuthorDto, IRequest<BookWithAuthorsDto>
    {
    }

    public class LinkBookToAuthorRequestHandler : IRequestHandler<LinkBookToAuthorRequest, BookWithAuthorsDto>
    {
        private readonly AwesomeLibraryDbContext _context;
        private readonly IMapper _mapper;
        private readonly IBookService _bookService;

        public LinkBookToAuthorRequestHandler(AwesomeLibraryDbContext context, IMapper mapper, IBookService bookService)
        {
            _context = context;
            _mapper = mapper;
            _bookService = bookService;
        }

        public async Task<BookWithAuthorsDto> Handle(LinkBookToAuthorRequest request, CancellationToken cancellationToken)
        {
            await _context.BooksAuthors.AddAsync(_mapper.Map<BookAuthor>(request));
            await _context.SaveChangesAsync();
            return await _bookService.GetBookWithAuthors(request.BookId, cancellationToken);
        }
    }
}
