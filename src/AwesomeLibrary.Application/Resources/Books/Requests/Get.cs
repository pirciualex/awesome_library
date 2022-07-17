using AwesomeLibrary.Application.Resources.Books.Models;
using AwesomeLibrary.Application.Services.Interfaces;
using MediatR;

namespace AwesomeLibrary.Application.Resources.Books.Requests
{
    public class GetRequest : IRequest<BookWithAuthorsDto>
    {
        public Guid Id { get; set; }
    }

    public class GetRequestHandler : IRequestHandler<GetRequest, BookWithAuthorsDto>
    {
        private readonly IBookService _bookService;

        public GetRequestHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<BookWithAuthorsDto> Handle(GetRequest request, CancellationToken cancellationToken)
        {
            return await _bookService.GetBookWithAuthors(request.Id, cancellationToken);
        }
    }
}
