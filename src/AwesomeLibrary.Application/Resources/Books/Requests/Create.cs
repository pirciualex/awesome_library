using AwesomeLibrary.Application.Resources.Books.Models;
using AwesomeLibrary.Application.Services.Interfaces;
using MediatR;

namespace AwesomeLibrary.Application.Resources.Books.Requests
{
    public class CreateRequest : BookPostDto, IRequest<BookGetDto>
    {
    }

    public class CreateRequestHandler : IRequestHandler<CreateRequest, BookGetDto>
    {
        private readonly IBookService _bookService;

        public CreateRequestHandler(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<BookGetDto> Handle(CreateRequest request, CancellationToken cancellationToken)
        {
            return await _bookService.CreateBook(request, cancellationToken);
        }
    }
}
