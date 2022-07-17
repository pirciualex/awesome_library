using AwesomeLibrary.Application.Resources.BooksAuthors.Models;
using AwesomeLibrary.Application.Services.Interfaces;
using MediatR;

namespace AwesomeLibrary.Application.Resources.Books.Requests
{
    public class GetRequest : IRequest<BookWithAuthorsGetDto>
    {
        public Guid Id { get; set; }
    }

    public class GetRequestHandler : IRequestHandler<GetRequest, BookWithAuthorsGetDto>
    {
        private readonly IBookService _bookService;

        public GetRequestHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<BookWithAuthorsGetDto> Handle(GetRequest request, CancellationToken cancellationToken)
        {
            return await _bookService.GetBookWithAuthors(request.Id, cancellationToken);
        }
    }
}
