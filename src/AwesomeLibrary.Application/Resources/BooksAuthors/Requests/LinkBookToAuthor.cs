using AwesomeLibrary.Application.Resources.BooksAuthors.Models;
using AwesomeLibrary.Application.Services.Interfaces;
using MediatR;

namespace AwesomeLibrary.Application.Resources.BooksAuthors.Requests
{
    public class LinkBookToAuthorRequest : BookAuthorDto, IRequest<BookWithAuthorsGetDto>
    {
    }

    public class LinkBookToAuthorRequestHandler : IRequestHandler<LinkBookToAuthorRequest, BookWithAuthorsGetDto>
    {
        private readonly IBookService _bookService;
        private readonly IBookAuthorService _bookAuthorService;

        public LinkBookToAuthorRequestHandler(IBookService bookService, IBookAuthorService bookAuthorService)
        {
            _bookService = bookService;
            _bookAuthorService = bookAuthorService;
        }

        public async Task<BookWithAuthorsGetDto> Handle(LinkBookToAuthorRequest request, CancellationToken cancellationToken)
        {
            var bookAuthor = await _bookAuthorService.LinkBookToAuthor(request, cancellationToken);
            return await _bookService.GetBookWithAuthors(bookAuthor.BookId, cancellationToken);
        }
    }
}
