using AutoMapper;
using AwesomeLibrary.Application.Resources.Books.Models;
using AwesomeLibrary.Application.Resources.BooksAuthors.Models;
using AwesomeLibrary.Application.Services.Interfaces;
using MediatR;

namespace AwesomeLibrary.Application.Resources.BooksAuthors.Requests
{
    public class CreateBookWithAuthorsRequest : BookWithAuthorPostDto, IRequest<BookWithAuthorsGetDto>
    {
    }

    public class CreateBookWithAuthorsRequestHandler : IRequestHandler<CreateBookWithAuthorsRequest, BookWithAuthorsGetDto>
    {
        private readonly IAuthorService _authorService;
        private readonly IBookService _bookService;
        private readonly IBookAuthorService _bookAuthorService;
        private readonly IMapper _mapper;

        public CreateBookWithAuthorsRequestHandler(IAuthorService authorService, IBookService bookService, IBookAuthorService bookAuthorService, IMapper mapper)
        {
            _authorService = authorService;
            _bookService = bookService;
            _bookAuthorService = bookAuthorService;
            _mapper = mapper;
        }

        public async Task<BookWithAuthorsGetDto> Handle(CreateBookWithAuthorsRequest request, CancellationToken cancellationToken)
        {
            var bookToCreate = _mapper.Map<BookPostDto>(request);
            var bookInDb = await _bookService.CreateBook(bookToCreate, cancellationToken);
            foreach (var author in request.Authors)
            {
                var authorInDb = await _authorService.CreateAuthor(author, cancellationToken);
                await _bookAuthorService.LinkBookToAuthor(
                    new BookAuthorDto
                    {
                        AuthorId = authorInDb.Id,
                        BookId = bookInDb.Id,
                    },
                    cancellationToken);
            }
            var bookToReturn = await _bookService.GetBookWithAuthors(bookInDb.Id, cancellationToken);
            return bookToReturn;
        }
    }
}
